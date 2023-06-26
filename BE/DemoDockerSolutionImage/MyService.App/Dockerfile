#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyService.App/MyService.App.csproj", "MyService.App/"]
COPY ["MyService.Domain/MyService.Domain.csproj", "MyService.Domain/"]
COPY ["MyService.Infrastructure/MyService.Infrastructure.csproj", "MyService.Infrastructure/"]
RUN dotnet restore "MyService.App/MyService.App.csproj"
COPY . .
WORKDIR "/src/MyService.App"
RUN dotnet build "MyService.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyService.App.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyService.App.dll"]