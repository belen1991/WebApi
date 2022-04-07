#get base sdk from windows

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
USER root
RUN mkdir /api
WORKDIR /api

#Copy the CSPROJ file and restore dependencies

COPY ./WebApi *.csproj ./
RUN dotnet restore

#Copy the project file

COPY ./WebApi .
#RUN dotnet publish -c release -o /app 
RUN dotnet publish -c release -o /app

#Generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /api
COPY --from=build /app .
ENTRYPOINT [ "dotnet","dockerApi.dll" ]