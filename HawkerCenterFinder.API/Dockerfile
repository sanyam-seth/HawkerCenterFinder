FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HawkerCenterFinder/HawkerCenterFinder.csproj", "HawkerCenterFinder/"]
RUN dotnet restore "HawkerCenterFinder/HawkerCenterFinder.csproj"
COPY . .
WORKDIR "/src/HawkerCenterFinder"
RUN dotnet build "HawkerCenterFinder.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HawkerCenterFinder.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HawkerCenterFinder.API.dll", "--server.urls", "http://0.0.0.0:80"]
