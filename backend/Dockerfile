FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 80

COPY . .

RUN dotnet restore

COPY . .
RUN dotnet build -c Release --no-restore

FROM build AS publish
RUN dotnet publish -c Release --no-restore -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=publish /app/out ./

ENTRYPOINT ["dotnet", "Web.dll"]
