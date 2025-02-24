FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AutoFront/AutoFront/AutoFront.csproj", "AutoFront/AutoFront/"]
COPY ["AutoFront/AutoFront.Client/AutoFront.Client.csproj", "AutoFront/AutoFront.Client/"]
RUN dotnet restore "AutoFront/AutoFront/AutoFront.csproj"

# New line: Install the WebAssembly tools
RUN dotnet workload install wasm-tools \

COPY . .
WORKDIR "/src/AutoFront/AutoFront"
RUN dotnet build "AutoFront.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AutoFront.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AutoFront.dll"]
