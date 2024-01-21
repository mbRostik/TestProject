#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ApiGateWay/OcelotGateWay/OcelotGateWay.csproj", "ApiGateWay/OcelotGateWay/"]
RUN dotnet restore "./ApiGateWay/OcelotGateWay/./OcelotGateWay.csproj"
COPY . .
WORKDIR "/src/ApiGateWay/OcelotGateWay"
RUN dotnet build "./OcelotGateWay.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./OcelotGateWay.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["ApiGateWay/OcelotGateWay/appsettings.json", "./"]
COPY ["ApiGateWay/OcelotGateWay/ocelot.json", "./"]
ENTRYPOINT ["dotnet", "OcelotGateWay.dll"]