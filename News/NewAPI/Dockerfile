#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["News/NewAPI/NewAPI.csproj", "News/NewAPI/"]
COPY ["News/Application/Application.csproj", "News/Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["News/Infrastructure/Infrastructure.csproj", "News/Infrastructure/"]
RUN dotnet restore "./News/NewAPI/./NewAPI.csproj"
COPY . .
WORKDIR "/src/News/NewAPI"
RUN dotnet build "./NewAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./NewAPI.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["News/NewAPI/appsettings.json", "./"]

ENTRYPOINT ["dotnet", "NewAPI.dll"]