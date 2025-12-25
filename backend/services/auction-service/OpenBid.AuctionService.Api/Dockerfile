# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["backend/services/auction-service/OpenBid.AuctionService.Api/OpenBid.AuctionService.Api.csproj", "backend/services/auction-service/OpenBid.AuctionService.Api/"]
COPY ["backend/contracts/Openbid.AuctionService.Contracts/Openbid.AuctionService.Contracts.csproj", "backend/contracts/Openbid.AuctionService.Contracts/"]
COPY ["backend/services/auction-service/OpenBid.AuctionService.Entities/OpenBid.AuctionService.Entities.csproj", "backend/services/auction-service/OpenBid.AuctionService.Entities/"]

# Restore

RUN dotnet restore "backend/services/auction-service/OpenBid.AuctionService.Api/OpenBid.AuctionService.Api.csproj"

# Copy everything else
COPY . .

# Build
WORKDIR "/src/backend/services/auction-service/OpenBid.AuctionService.Api"
RUN dotnet build "OpenBid.AuctionService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build


# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OpenBid.AuctionService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenBid.AuctionService.Api.dll"]