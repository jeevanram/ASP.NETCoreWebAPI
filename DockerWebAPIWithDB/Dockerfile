FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS publish
WORKDIR /src
COPY *.sln .
COPY ["DockerWebAPIWithDB/DockerWebAPIWithDB.csproj", "./DockerWebAPIWithDB/"]
COPY ["WebAPI.Security/WebAPI.Security.csproj","./WebAPI.Security/"]

RUN dotnet restore 

COPY DockerWebAPIWithDB/. ./DockerWebAPIWithDB/
COPY WebAPI.Security/. ./WebAPI.Security/

WORKDIR /src/DockerWebAPIWithDB
RUN dotnet publish "DockerWebAPIWithDB.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerWebAPIWithDB.dll"]