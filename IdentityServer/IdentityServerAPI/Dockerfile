#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["IdentityServer/IdentityServerAPI/IdentityServerAPI.csproj", "IdentityServer/IdentityServerAPI/"]
COPY ["IdentityServer/Application/Application.csproj", "IdentityServer/Application/"]
COPY ["MessageBus/MessageBus.csproj", "MessageBus/"]
COPY ["IdentityServer/Infrastructure/Infrastructure.csproj", "IdentityServer/Infrastructure/"]
RUN dotnet restore "./IdentityServer/IdentityServerAPI/./IdentityServerAPI.csproj"
COPY . .
WORKDIR "/src/IdentityServer/IdentityServerAPI"
RUN dotnet build "./IdentityServerAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./IdentityServerAPI.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["IdentityServer/IdentityServerAPI/appsettings.json", "./"]

ENTRYPOINT ["dotnet", "IdentityServerAPI.dll"]