#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Boticario.API/Boticario.API.csproj", "Boticario.API/"]
RUN dotnet restore "Boticario.API/Boticario.API.csproj"
COPY . .
WORKDIR "/src/Boticario.API"
RUN dotnet build "Boticario.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Boticario.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Boticario.API.dll"]