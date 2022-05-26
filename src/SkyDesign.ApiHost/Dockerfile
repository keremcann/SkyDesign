#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/SkyDesign.ApiHost/SkyDesign.ApiHost.csproj", "src/SkyDesign.ApiHost/"]
COPY ["src/SkyDesign.Dapper/SkyDesign.Dapper.csproj", "src/SkyDesign.Dapper/"]
COPY ["src/SkyDesign.Domain/SkyDesign.Domain.csproj", "src/SkyDesign.Domain/"]
COPY ["src/SkyDesign.Core/SkyDesign.Core.csproj", "src/SkyDesign.Core/"]
COPY ["src/SkyDesign.Domain.Shared/SkyDesign.Domain.Shared.csproj", "src/SkyDesign.Domain.Shared/"]
COPY ["src/SkyDesign.EntityFrameworkCore/SkyDesign.EntityFrameworkCore.csproj", "src/SkyDesign.EntityFrameworkCore/"]
COPY ["src/SkyDesign.Application/SkyDesign.Application.csproj", "src/SkyDesign.Application/"]
COPY ["src/SkyDesign.Application.Contract/SkyDesign.Application.Contract.csproj", "src/SkyDesign.Application.Contract/"]
RUN dotnet restore "src/SkyDesign.ApiHost/SkyDesign.ApiHost.csproj"
COPY . .
WORKDIR "/src/src/SkyDesign.ApiHost"
RUN dotnet build "SkyDesign.ApiHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkyDesign.ApiHost.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SkyDesign.ApiHost.dll"]