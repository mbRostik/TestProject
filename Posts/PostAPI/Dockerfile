#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Posts/PostAPI/PostAPI.csproj", "Posts/PostAPI/"]
COPY ["Posts/Application/Application.csproj", "Posts/Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["MessageBus/MessageBus.csproj", "MessageBus/"]
COPY ["Posts/Infrastructure/Infrastructure.csproj", "Posts/Infrastructure/"]
RUN dotnet restore "./Posts/PostAPI/./PostAPI.csproj"
COPY . .
WORKDIR "/src/Posts/PostAPI"
RUN dotnet build "./PostAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./PostAPI.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["Posts/PostAPI/appsettings.json", "./"]

ENTRYPOINT ["dotnet", "PostAPI.dll"]