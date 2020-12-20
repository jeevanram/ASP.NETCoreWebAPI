FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as publish
WORKDIR /src
COPY ["DockerConsoleApp/DockerConsoleApp.csproj", "DockerConsoleApp/"]
RUN dotnet restore "DockerConsoleApp/DockerConsoleApp.csproj"
COPY . .
WORKDIR "/src/DockerConsoleApp"
RUN dotnet publish "DockerConsoleApp.csproj" -c Release -o /app/publish
FROM mcr.microsoft.com/dotnet/core/runtime:3.1
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","DockerConsoleApp.dll"]