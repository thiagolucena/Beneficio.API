#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /app
#COPY . .
COPY ["Beneficio.API/Beneficio.API.csproj", "Beneficio.API/"]
COPY ["Beneficio.Domain/Beneficio.Domain.csproj", "Beneficio.Domain/"]
COPY ["Beneficio.Infra.CrossCutting/Beneficio.Infra.CrossCutting.csproj", "Beneficio.Infra.CrossCutting/"]
COPY ["Beneficio.Infra.Data/Beneficio.Infra.Data.csproj", "Beneficio.Infra.Data/"]
COPY ["Beneficio.Service/Beneficio.Service.csproj", "Beneficio.Service/"]
RUN ls
RUN dotnet restore "Beneficio.API/Beneficio.API.csproj"
COPY . .
WORKDIR "Beneficio.API"
RUN dotnet build "Beneficio.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Beneficio.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#COPY cert-aspnetcore.pfx .

ENTRYPOINT ["dotnet", "Beneficio.API.dll"]