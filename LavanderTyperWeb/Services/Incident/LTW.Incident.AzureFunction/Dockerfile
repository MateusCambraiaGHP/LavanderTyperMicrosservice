# Veja https://aka.ms/customizecontainer para mais informações sobre como personalizar seu container de depuração.

# Use a imagem base adequada para o Azure Functions em Linux
FROM mcr.microsoft.com/azure-functions/dotnet-isolated:4-dotnet-isolated8.0 AS base
WORKDIR /home/site/wwwroot
EXPOSE 8080

# Usando a imagem do SDK do .NET 8.0 para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Incident/LTW.Incident.AzureFunction/LTW.Incident.AzureFunction.csproj", "Services/Incident/LTW.Incident.AzureFunction/"]
RUN dotnet restore "./Services/Incident/LTW.Incident.AzureFunction/LTW.Incident.AzureFunction.csproj"
COPY . .
WORKDIR "/src/Services/Incident/LTW.Incident.AzureFunction"
RUN dotnet build "./LTW.Incident.AzureFunction.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publicar o projeto
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LTW.Incident.AzureFunction.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Criar a imagem final para o Azure Functions
FROM base AS final
WORKDIR /home/site/wwwroot
COPY --from=publish /app/publish .
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true
