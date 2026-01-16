# Используем aspnet образ вместо runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SmartCartBackend.API/SmartCartBackend.API.csproj", "SmartCartBackend.API/"]
COPY ["SmartCartBackend.Application/SmartCartBackend.Application.csproj", "SmartCartBackend.Application/"]
COPY ["SmartCartBackend.Domain/SmartCartBackend.Domain.csproj", "SmartCartBackend.Domain/"]
COPY ["SmartCartBackend.Infrastructure/SmartCartBackend.Infrastructure.csproj", "SmartCartBackend.Infrastructure/"]
COPY ["SmartCartBackend.Common/SmartCartBackend.Common.csproj", "SmartCartBackend.Common/"]
RUN dotnet restore "SmartCartBackend.API/SmartCartBackend.API.csproj"
COPY . .
WORKDIR "/src/SmartCartBackend.API"
RUN dotnet build "./SmartCartBackend.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SmartCartBackend.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartCartBackend.API.dll"]