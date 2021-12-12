#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["IOT-ArduinoDashboard/IOT-ArduinoDashboard.csproj", "IOT-ArduinoDashboard/"]
COPY ["ArduinoIOT-Library/ArduinoIOTLibrary.csproj", "ArduinoIOT-Library/"]
RUN dotnet restore "IOT-ArduinoDashboard/IOT-ArduinoDashboard.csproj"
COPY . .
WORKDIR "/src/IOT-ArduinoDashboard"
RUN dotnet build "IOT-ArduinoDashboard.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IOT-ArduinoDashboard.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IOT-ArduinoDashboard.dll"]