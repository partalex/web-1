﻿FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy and restore Shared project
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "Shared/Shared.csproj"

COPY ["Frontend/Frontend.csproj", "Frontend/"]
RUN dotnet restore "Frontend/Frontend.csproj"
COPY . .
WORKDIR "/src/Frontend"
RUN dotnet build "Frontend.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Install wasm-tools
RUN dotnet workload install wasm-tools

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Frontend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Frontend.dll"]
