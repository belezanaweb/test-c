#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-nanoserver-1809 AS build
WORKDIR /src
COPY ["BelezanaWeb/BelezanaWeb.csproj", "BelezanaWeb/"]
RUN dotnet restore "BelezanaWeb/BelezanaWeb.csproj"
COPY . .
WORKDIR "/src/BelezanaWeb"
RUN dotnet build "BelezanaWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BelezanaWeb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BelezanaWeb.dll"]