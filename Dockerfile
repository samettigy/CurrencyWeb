FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app
COPY ./CurrencyWeb.Entities/*.csproj ./CurrencyWeb.Entities/
COPY ./CurrencyWeb.DAL/*.csproj ./CurrencyWeb.DAL/
COPY ./CurrencyWeb.Business/*.csproj ./CurrencyWeb.Business/
COPY ./CurrencyWeb.BusinessAPI/*.csproj ./CurrencyWeb.BusinessAPI/
COPY ./CurrencyWeb.DataAPI/*.csproj ./CurrencyWeb.DataAPI/
COPY ./CurrencyWeb.MVC/*.csproj ./CurrencyWeb.MVC/
COPY *.sln .
RUN dotnet restore
COPY . .
RUN dotnet publish ./CurrencyWeb.DataAPI/*.csproj -o /publish/
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /publish .
ENV ASPNETCORE_URLS="http://*:1453"
ENTRYPOINT [ "dotnet", "CurrencyWeb.DataAPI.dll" ]








