FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["RealEstate.API/RealEstate.API.csproj", "RealEstate.API/"]
COPY ["RealEstate.Core/RealEstate.API.csproj", "RealEstate.Core/"]
RUN dotnet restore "RealEstate.API/RealEstate.API.csproj"
COPY . .
RUN dotnet build "RealEstate.API/RealEstate.API.csproj" -v q -c Release -o /app/build

FROM build AS publish
RUN dotnet build "RealEstate.API/RealEstate.API.csproj" -v q -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["dotnet", "RealEstate.API.dll"]