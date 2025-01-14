# Veja https://aka.ms/customizecontainer para mais informações sobre como personalizar seu container de depuração.

# Use imagens base Linux em vez de Windows
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Resources/LTW.Resources.API/LTW.Resources.API.csproj", "Services/Resources/LTW.Resources.API/"]
RUN dotnet restore "./Services/Resources/LTW.Resources.API/LTW.Resources.API.csproj"
COPY . .
WORKDIR "/src/Services/Resources/LTW.Resources.API"
RUN dotnet build "./LTW.Resources.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LTW.Resources.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LTW.Resources.API.dll"]
