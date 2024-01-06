FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebChatSignalR.Pl.API/WebChatSignalR.Pl.API.csproj", "WebChatSignalR.Pl.API/"]
RUN dotnet restore "WebChatSignalR.Pl.API/WebChatSignalR.Pl.API.csproj"
COPY . .
WORKDIR "/src/WebChatSignalR.Pl.API"
RUN dotnet build "WebChatSignalR.Pl.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebChatSignalR.Pl.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebChatSignalR.Pl.API.dll"]
