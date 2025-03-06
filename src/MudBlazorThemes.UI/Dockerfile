#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

ARG BUILD_CONFIGURATION=Release
ARG DB_NAME
ARG DB_PORT
ARG DB_USER
ARG DB_PASSWORD
ARG GIT_DOMAIN
ARG GIT_CLIENTID

WORKDIR /src
COPY ["src/MudBlazorThemes.UI/MudBlazorThemes.UI.csproj", "MudBlazorThemes.UI/"]
COPY ["src/MudBlazorThemes.DAL/MudBlazorThemes.DAL.csproj", "MudBlazorThemes.DAL/"]
RUN dotnet restore "./MudBlazorThemes.UI/MudBlazorThemes.UI.csproj"
COPY . .

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR "/src/MudBlazorThemes.UI"
RUN dotnet publish "MudBlazorThemes.UI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Set environment variables from build args
ENV dbName=$DB_NAME
ENV dbPort=$DB_PORT
ENV dbUser=$DB_USER
ENV dbPassword=$DB_PASSWORD
ENV domain=$GIT_DOMAIN
ENV clientId=$GIT_CLIENTID

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MudBlazorThemes.UI.dll"]
