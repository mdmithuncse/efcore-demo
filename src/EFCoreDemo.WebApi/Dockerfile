#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/EFCoreDemo.WebApi/EFCoreDemo.WebApi.csproj", "src/EFCoreDemo.WebApi/"]
RUN dotnet restore "./src/EFCoreDemo.WebApi/EFCoreDemo.WebApi.csproj"
COPY . .
WORKDIR "/src/src/EFCoreDemo.WebApi"
RUN dotnet build "./EFCoreDemo.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EFCoreDemo.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EFCoreDemo.WebApi.dll"]