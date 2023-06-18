FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Hatdieu.IdentityServer.STS.Identity/Hatdieu.IdentityServer.STS.Identity.csproj", "src/Hatdieu.IdentityServer.STS.Identity/"]
COPY ["src/Hatdieu.IdentityServer.Admin.EntityFramework.Shared/Hatdieu.IdentityServer.Admin.EntityFramework.Shared.csproj", "src/Hatdieu.IdentityServer.Admin.EntityFramework.Shared/"]
COPY ["src/Hatdieu.IdentityServer.Shared/Hatdieu.IdentityServer.Shared.csproj", "src/Hatdieu.IdentityServer.Shared/"]
RUN dotnet restore "src/Hatdieu.IdentityServer.STS.Identity/Hatdieu.IdentityServer.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/Hatdieu.IdentityServer.STS.Identity"
RUN dotnet build "Hatdieu.IdentityServer.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hatdieu.IdentityServer.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Hatdieu.IdentityServer.STS.Identity.dll"]