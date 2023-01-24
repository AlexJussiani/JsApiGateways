#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./ApiGateways/Js.ApiGateways/Js.ApiGateways/Js.ApiGateways.csproj", "ApiGateways/Js.ApiGateways/Js.ApiGateways/"]
COPY ["./ApiGateways/Js.ApiGateways/building blocks/JS.WebAPI.Core/JS.WebAPI.Core.csproj", "ApiGateways/Js.ApiGateways/building blocks/JS.WebAPI.Core/"]
COPY ["./ApiGateways/Js.ApiGateways/building blocks/JS.Core/JS.Core.csproj", "ApiGateways/Js.ApiGateways/building blocks/JS.Core/"]
RUN dotnet restore "./ApiGateways/Js.ApiGateways/Js.ApiGateways/Js.ApiGateways.csproj"
COPY . .
WORKDIR "./ApiGateways/Js.ApiGateways/Js.ApiGateways"
RUN dotnet build "Js.ApiGateways.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Js.ApiGateways.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Js.ApiGateways.dll"]