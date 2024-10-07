FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ExcelUpdater.csproj", "."]
RUN dotnet restore "./ExcelUpdater.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ExcelUpdater.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExcelUpdater.csproj" -c Release -o /app/publish /p:UseAppHost=false


#asp net core
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExcelUpdater.dll"]
