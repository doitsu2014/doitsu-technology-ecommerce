FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/IdentityServer.STS.Identity/IdentityServer.STS.Identity.csproj", "src/IdentityServer.STS.Identity/"]
COPY ["src/IdentityServer.Admin.EntityFramework.Shared/IdentityServer.Admin.EntityFramework.Shared.csproj", "src/IdentityServer.Admin.EntityFramework.Shared/"]
COPY ["src/IdentityServer.Shared/IdentityServer.Shared.csproj", "src/IdentityServer.Shared/"]
RUN dotnet restore "src/IdentityServer.STS.Identity/IdentityServer.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/IdentityServer.STS.Identity"
RUN dotnet build "IdentityServer.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServer.STS.Identity.csproj" -c Release -o /app/publish
 
# Generate Dev Certs from SDKs
RUN dotnet dev-certs https --clean
RUN dotnet dev-certs https -ep /app/https/default-certificate.pfx -p changeme
RUN dotnet dev-certs https --trust

FROM base AS final
ARG HttpsCertName=aspnetapp

WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=publish /app/https /https

ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/default-certificate.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=changeme
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENV ASPNETCORE_URLS=https://+:44310;http://+:5000
ENTRYPOINT ["dotnet", "IdentityServer.STS.Identity.dll"]