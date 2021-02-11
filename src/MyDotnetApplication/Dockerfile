FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
COPY ["MyDotnetApplication/MyDotnetApplication.csproj", "MyDotnetApplication/"]
RUN dotnet restore "MyDotnetApplication/MyDotnetApplication.csproj"
COPY . .
WORKDIR "MyDotnetApplication/"
RUN dotnet build "MyDotnetApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyDotnetApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /apps
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "MyDotnetApplication.dll"]