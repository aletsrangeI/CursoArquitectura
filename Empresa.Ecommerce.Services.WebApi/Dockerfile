FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /src

COPY . .

WORKDIR /src/Empresa.Ecommerce.Services.WebApi
RUN dotnet restore
RUN dotnet publis -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app

COPY --from=build-env /src/Empresa.Ecommerce.Services.WebApi/out ./

ENTRYPOINT ["dotnet", "Empresa.Ecommerce.Services.WebApi.dll"]