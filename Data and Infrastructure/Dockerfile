FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DataLayer/DataLayer.csproj", "DataLayer/"]
RUN dotnet restore "DataLayer/DataLayer.csproj"
COPY . .
WORKDIR "/src/DataLayer"
RUN dotnet build "DataLayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DataLayer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DataLayer.dll"]
