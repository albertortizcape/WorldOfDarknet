#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["game-api/src/Game.Api.Host/Game.Api.Host.csproj", "game-api/src/Game.Api.Host/"]
COPY ["game-api/src/Game.Api/Game.Api.csproj", "game-api/src/Game.Api/"]
COPY ["game-api/src/Game.Infrastructure/Game.Infrastructure.csproj", "game-api/src/Game.Infrastructure/"]
COPY ["game-api/src/Game.Domain/Game.Domain.csproj", "game-api/src/Game.Domain/"]
RUN dotnet restore "game-api/src/Game.Api.Host/Game.Api.Host.csproj"
COPY . .
WORKDIR "/src/game-api/src/Game.Api.Host"
RUN dotnet build "Game.Api.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Game.Api.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "Game.Api.Host.dll"]
# Use the following instead for Heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Game.Api.Host.dll