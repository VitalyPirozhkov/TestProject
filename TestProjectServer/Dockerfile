# ”казываем базовый образ с .NET SDK
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5020
EXPOSE 5021

# ”казываем базовый образ с .NET SDK дл€ сборки приложени€
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src/TestProjectServer
COPY . .
RUN dotnet restore "TestProjectServer.csproj"
RUN dotnet build "TestProjectServer.csproj" -c Release -o /app/build

# ѕубликуем приложение в директорию /app/publish
FROM build AS publish
RUN dotnet publish "TestProjectServer.csproj" -c Release -o /app/publish

# —борка финального образа с серверным приложением
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestProjectServer.dll"]
