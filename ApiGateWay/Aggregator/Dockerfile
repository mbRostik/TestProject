#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ApiGateWay/Aggregator/Aggregator.csproj", "ApiGateWay/Aggregator/"]
COPY ["Domain/Domain.csproj", "Domain/"]
RUN dotnet restore "./ApiGateWay/Aggregator/./Aggregator.csproj"
COPY . .
WORKDIR "/src/ApiGateWay/Aggregator"
RUN dotnet build "./Aggregator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Aggregator.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["ApiGateWay/Aggregator/appsettings.json", "./"]
ENTRYPOINT ["dotnet", "Aggregator.dll"]