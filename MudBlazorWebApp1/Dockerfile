FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MudBlazorWebApp1/MudBlazorWebApp1.csproj", "MudBlazorWebApp1/"]
RUN dotnet restore "MudBlazorWebApp1/MudBlazorWebApp1.csproj"
COPY . .
WORKDIR "/src/MudBlazorWebApp1"
RUN dotnet build "MudBlazorWebApp1.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MudBlazorWebApp1.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MudBlazorWebApp1.dll"]
