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
COPY ["Services/Payment/LTW.Payment.API/LTW.Payment.API.csproj", "Services/Payment/LTW.Payment.API/"]
RUN dotnet restore "./Services/Payment/LTW.Payment.API/LTW.Payment.API.csproj"
COPY . .
WORKDIR "/src/Services/Payment/LTW.Payment.API"
RUN dotnet build "./LTW.Payment.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LTW.Payment.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LTW.Payment.API.dll"]
