#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/BasketService/BasketService.API/BasketService.API.csproj", "src/BasketService/BasketService.API/"]
RUN dotnet restore "src/BasketService/BasketService.API/BasketService.API.csproj"
COPY . .
WORKDIR "/src/src/BasketService/BasketService.API"
RUN dotnet build "BasketService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasketService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasketService.API.dll"]
