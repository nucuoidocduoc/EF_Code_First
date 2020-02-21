FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /app

# copy csproj and restore as distinct layers
COPY ./EF_Code_First/EF_Code_First.csproj ./EF_Code_First/
RUN dotnet restore EF_Code_First

# copy Entities csproj and restore as distinct layers
COPY ./Entities/Entities.csproj ./Entities/
RUN dotnet restore Entities

# copy Repository csproj and restore as distinct layers
COPY ./Repository/Repository.csproj ./Repository/
RUN dotnet restore Repository

# copy Contracts csproj and restore as distinct layers
COPY ./Contracts/Contracts.csproj ./Contracts/
RUN dotnet restore Contracts

# copy everything else and build app
COPY ./EF_Code_First/. ./EF_Code_First/
COPY ./Entities/. ./Entities/
COPY ./Repository/. ./Repository/
COPY ./Contracts/. ./Contracts/

RUN dotnet publish ./EF_Code_First/EF_Code_First.csproj -c Release -o /publish/

WORKDIR /publish

ENTRYPOINT ["dotnet", "EF_Code_First.dll"]