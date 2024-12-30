#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LavanderTyper/LavanderTyperWeb.csproj", "LavanderTyper/"]
COPY ["LavanderTyper.Application/LavanderTyperWeb.Application.csproj", "LavanderTyper.Application/"]
COPY ["LavanderTyper.Core/LavanderTyperWeb.Core.csproj", "LavanderTyper.Core/"]
COPY ["LavanderTyper.Data/LavanderTyperWeb.Data.csproj", "LavanderTyper.Data/"]
COPY ["LavanderTyper.Domain/LavanderTyperWeb.Domain.csproj", "LavanderTyper.Domain/"]
COPY ["LavanderTyper.Infrastructure/LavanderTyperWeb.Infrastructure.csproj", "LavanderTyper.Infrastructure/"]
RUN dotnet restore "./LavanderTyper/./LavanderTyperWeb.csproj"
COPY . .
WORKDIR "/src/LavanderTyper"
RUN dotnet build "./LavanderTyperWeb.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LavanderTyperWeb.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LavanderTyperWeb.dll"]