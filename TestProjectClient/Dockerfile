FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5010
EXPOSE 5011

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src/TestProjectClient
COPY . .
RUN dotnet restore "TestProjectClient.csproj"
RUN dotnet build "TestProjectClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestProjectClient.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestProjectClient.dll"]
