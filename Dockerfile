FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./src/HawkerCenterFinder.API/HawkerCenterFinder.API.csproj"
WORKDIR "src/HawkerCenterFinder.API"
RUN dotnet build "HawkerCenterFinder.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HawkerCenterFinder.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HawkerCenterFinder.API.dll", "--server.urls", "http://0.0.0.0:80"]