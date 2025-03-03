#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ThemeCreatorMudBlazor.UI/ThemeCreatorMudBlazor.UI.csproj", "ThemeCreatorMudBlazor.UI/"]
COPY ["ThemeCreatorMudBlazor.DAL/ThemeCreatorMudBlazor.DAL.csproj", "ThemeCreatorMudBlazor.DAL/"]
RUN dotnet restore "./ThemeCreatorMudBlazor.UI/ThemeCreatorMudBlazor.UI.csproj"
COPY . .
WORKDIR "/src/ThemeCreatorMudBlazor.UI"
RUN dotnet build "./ThemeCreatorMudBlazor.UI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ThemeCreatorMudBlazor.UI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Copy the SQLite database file
COPY ThemeCreatorMudBlazor.UI/ThemeCreator.db /app/publish/ThemeCreator.db
RUN chmod 666 /app/publish/ThemeCreator.db

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ThemeCreatorMudBlazor.UI.dll"]