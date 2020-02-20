FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

ARG BUILD_TIME
ENV ASPNETCORE_ENVIRONMENT=$BUILD_TIME

WORKDIR /app

# copy csproj and restore as distinct layers
COPY LicenseManagerServer/LicenseManagerServer.csproj ./LicenseManager/
RUN dotnet restore LicenseManager

# copy Entities csproj and restore as distinct layers
COPY Entities/Entities.csproj ./Entities/
RUN dotnet restore Entities

# copy LoggerService csproj and restore as distinct layers
COPY LoggerService/LoggerService.csproj ./LoggerService/
RUN dotnet restore LoggerService

# copy Repository csproj and restore as distinct layers
COPY Repository/Repository.csproj ./Repository/
RUN dotnet restore Repository

# copy Contracts csproj and restore as distinct layers
COPY Contracts/Contracts.csproj ./Contracts/
RUN dotnet restore Contracts

# copy everything else and build app
COPY LicenseManagerServer/. ./LicenseManager/
COPY Entities/. ./Entities/
COPY LoggerService/. ./LoggerService/
COPY Repository/. ./Repository/
COPY Contracts/. ./Contracts/

WORKDIR /app/LicenseManager
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/LicenseManager/out ./
ENTRYPOINT ["dotnet", "LicenseManagerServer.dll"]

RUN mkdir -p /app/Resources/Installer