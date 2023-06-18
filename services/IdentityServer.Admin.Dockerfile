FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Hatdieu.IdentityServer.Admin/Hatdieu.IdentityServer.Admin.csproj", "src/Hatdieu.IdentityServer.Admin/"]
COPY ["src/Hatdieu.IdentityServer.Admin.EntityFramework.Shared/Hatdieu.IdentityServer.Admin.EntityFramework.Shared.csproj", "src/Hatdieu.IdentityServer.Admin.EntityFramework.Shared/"]
COPY ["src/Hatdieu.IdentityServer.Admin.EntityFramework.SqlServer/Hatdieu.IdentityServer.Admin.EntityFramework.SqlServer.csproj", "src/Hatdieu.IdentityServer.Admin.EntityFramework.SqlServer/"]
COPY ["src/Hatdieu.IdentityServer.Shared/Hatdieu.IdentityServer.Shared.csproj", "src/Hatdieu.IdentityServer.Shared/"]
COPY ["src/Hatdieu.IdentityServer.Admin.EntityFramework.PostgreSQL/Hatdieu.IdentityServer.Admin.EntityFramework.PostgreSQL.csproj", "src/Hatdieu.IdentityServer.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/Hatdieu.IdentityServer.Admin.EntityFramework.MySql/Hatdieu.IdentityServer.Admin.EntityFramework.MySql.csproj", "src/Hatdieu.IdentityServer.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/Hatdieu.IdentityServer.Admin/Hatdieu.IdentityServer.Admin.csproj"
COPY . .
WORKDIR "/src/src/Hatdieu.IdentityServer.Admin"
RUN dotnet build "Hatdieu.IdentityServer.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hatdieu.IdentityServer.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Hatdieu.IdentityServer.Admin.dll"]