FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY ["src/DataQuality.ApplicationCore/DataQuality.ApplicationCore.csproj", "src/DataQuality.ApplicationCore/DataQuality.ApplicationCore.csproj"]
COPY ["src/DataQuality.Infrastructure.Otel/DataQuality.Infrastructure.Otel.csproj", "src/DataQuality.Infrastructure.Otel/DataQuality.Infrastructure.Otel.csproj"]
COPY ["src/DataQuality.Infrastructure.ServiceBus/DataQuality.Infrastructure.ServiceBus.csproj", "src/DataQuality.Infrastructure.ServiceBus/DataQuality.Infrastructure.ServiceBus.csproj"]
COPY ["src/DataQuality.Infrastructure.MicrosoftGraph/DataQuality.Infrastructure.MicrosoftGraph.csproj", "src/DataQuality.Infrastructure.MicrosoftGraph/DataQuality.Infrastructure.MicrosoftGraph.csproj"]
COPY ["src/DataQuality.Api/DataQuality.Api.csproj", "src/DataQuality.Api/DataQuality.Api.csproj"]
COPY ["test/DataQuality.ApplicationCore.UnitTests/DataQuality.ApplicationCore.UnitTests.csproj", "test/DataQuality.ApplicationCore.UnitTests/DataQuality.ApplicationCore.UnitTests.csproj"]

ARG FEEDER
ARG FEEDER_USERNAME
ARG FEEDER_PASSWORD

RUN dotnet nuget add source $FEEDER -n prod -u $FEEDER_USERNAME -p $FEEDER_PASSWORD --store-password-in-clear-text
RUN dotnet restore "src/DataQuality.ApplicationCore/DataQuality.ApplicationCore.csproj"
RUN dotnet restore "src/DataQuality.Api/DataQuality.Api.csproj"
RUN dotnet restore "test/DataQuality.ApplicationCore.UnitTests/DataQuality.ApplicationCore.UnitTests.csproj"

COPY . .

WORKDIR "/app/src/DataQuality.ApplicationCore"
RUN dotnet build "DataQuality.ApplicationCore.csproj" -c Release -o /app/packages/build
RUN dotnet pack "DataQuality.ApplicationCore.csproj" -c Release -o /app/packages/publish
RUN dotnet nuget push /app/packages/publish/*.nupkg -s $FEEDER -k $FEEDER_PASSWORD --skip-duplicate

WORKDIR "/app/src/DataQuality.Api"
RUN dotnet build "DataQuality.Api.csproj" -c Release -o /app/build
RUN dotnet publish "DataQuality.Api.csproj" -c Release -o /app/publish

RUN mkdir /app/publish/test-results/
WORKDIR /app

RUN dotnet test --collect "XPlat Code Coverage" --logger trx --results-directory /app/publish/test-results
RUN dotnet tool install --global dotnet-reportgenerator-globaltool --version 5.1.13
ENV PATH /root/.dotnet/tools:$PATH
RUN reportgenerator "-reports:/app/publish/test-results/*/coverage.cobertura.xml" "-targetdir:/app/publish/test-results/html-report" "-reporttypes:HtmlInline_AzurePipelines" 

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT ["dotnet", "DataQuality.Api.dll"]