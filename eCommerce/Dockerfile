FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["eCommerce/eCommerce.csproj", "eCommerce/"]
RUN dotnet restore "eCommerce/eCommerce.csproj"
COPY . .
WORKDIR "/src/eCommerce"
RUN dotnet build "eCommerce.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eCommerce.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eCommerce.dll"]
