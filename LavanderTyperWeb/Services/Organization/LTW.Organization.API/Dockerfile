# Veja https://aka.ms/customizecontainer para mais informações sobre como personalizar seu container de depuração.

# Use imagens base Linux para a versão .NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use o SDK do .NET para o build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Organization/LTW.Organization.API/LTW.Organization.API.csproj", "Services/Organization/LTW.Organization.API/"]
RUN dotnet restore "./Services/Organization/LTW.Organization.API/LTW.Organization.API.csproj"
COPY . .
WORKDIR "/src/Services/Organization/LTW.Organization.API"
RUN dotnet build "./LTW.Organization.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LTW.Organization.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LTW.Organization.API.dll"]
