FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DankHappyBot/DankHappyBot.csproj", "DankHappyBot/"]
RUN dotnet restore "DankHappyBot/DankHappyBot.csproj"
COPY . .
WORKDIR "/src/DankHappyBot"
RUN dotnet build "DankHappyBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DankHappyBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DankHappyBot.dll"]
