FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Library/Library.csproj", "Library/"]
RUN dotnet restore "Library/Library.csproj"
COPY . .
WORKDIR "/src/Library"
RUN dotnet build "Library.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Library.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Library.dll"]
