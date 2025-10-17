#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Technical/NovinMeyar.Technical.Api/NovinMeyar.Technical.Api.csproj", "Technical/NovinMeyar.Technical.Api/"]
COPY ["Technical/NovinMeyar.Technical.DataLayer/NovinMeyar.Technical.DataLayer.csproj", "Technical/NovinMeyar.Technical.DataLayer/"]
COPY ["Domain/NovinMeyar.Domain/NovinMeyar.Domain.csproj", "Domain/NovinMeyar.Domain/"]
COPY ["Helper/NovinMeyar.Helpers/NovinMeyar.Helpers.csproj", "Helper/NovinMeyar.Helpers/"]
COPY ["Contract/NovinMeyar.Contract/NovinMeyar.Contract.csproj", "Contract/NovinMeyar.Contract/"]
RUN dotnet restore "Technical/NovinMeyar.Technical.Api/NovinMeyar.Technical.Api.csproj"
COPY . .
WORKDIR "/src/Technical/NovinMeyar.Technical.Api"
RUN dotnet build "NovinMeyar.Technical.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NovinMeyar.Technical.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NovinMeyar.Technical.Api.dll"]