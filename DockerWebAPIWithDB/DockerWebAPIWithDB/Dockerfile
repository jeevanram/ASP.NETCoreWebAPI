FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS publish
WORKDIR /src
COPY ["DockerWebAPIWithDB.csproj", "."]
RUN dotnet restore "DockerWebAPIWithDB.csproj"
COPY . .
WORKDIR /src
RUN dotnet publish "DockerWebAPIWithDB.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerWebAPIWithDB.dll"]