#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/InstantPOS.WebAPI/InstantPOS.WebAPI.csproj", "src/InstantPOS.WebAPI/"]
COPY ["src/InstantPOS.Infrastructure/InstantPOS.Infrastructure.csproj", "src/InstantPOS.Infrastructure/"]
COPY ["src/InstantPOS.Application/InstantPOS.Application.csproj", "src/InstantPOS.Application/"]
COPY ["src/InstantPOS.Domain/InstantPOS.Domain.csproj", "src/InstantPOS.Domain/"]
RUN dotnet restore "src/InstantPOS.WebAPI/InstantPOS.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/InstantPOS.WebAPI"
RUN dotnet build "InstantPOS.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InstantPOS.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstantPOS.WebAPI.dll"]