#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/EFCoreDemo.InnerJoin/EFCoreDemo.InnerJoin.csproj", "src/EFCoreDemo.InnerJoin/"]
COPY ["src/EFCoreDemo.Infrastructure/EFCoreDemo.Infrastructure.csproj", "src/EFCoreDemo.Infrastructure/"]
COPY ["src/EFCoreDemo.Domain/EFCoreDemo.Domain.csproj", "src/EFCoreDemo.Domain/"]
RUN dotnet restore "./src/EFCoreDemo.InnerJoin/EFCoreDemo.InnerJoin.csproj"
COPY . .
WORKDIR "/src/src/EFCoreDemo.InnerJoin"
RUN dotnet build "./EFCoreDemo.InnerJoin.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EFCoreDemo.InnerJoin.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EFCoreDemo.InnerJoin.dll"]