FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["chuckswAPI.csproj", "./"]
RUN dotnet restore "chuckswAPI.csproj"
COPY . .
# WORKDIR "/src/."
# RUN dotnet build "chuckswAPI.csproj" -c Release -o /app/build

# FROM build AS publish
RUN dotnet publish "chuckswAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "chuckswAPI.dll"]
