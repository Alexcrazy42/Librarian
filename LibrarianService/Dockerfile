FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 80

COPY *.sln .

COPY src/Core/Common/*.csproj ./src/Core/Common/
COPY src/Core/Domain/*.csproj ./src/Core/Domain/
COPY src/Core/Services/*.csproj ./src/Core/Services/

COPY src/Infrastructure/Swipty.MainService.Store.Db/*.csproj ./src/Infrastructure/Swipty.MainService.Store.Db/
COPY src/Infrastructure/Swipty.MainService.Store.Db.Migrations/*.csproj ./src/Infrastructure/Swipty.MainService.Store.Db.Migrations/
COPY src/Infrastructure/Swipty.MainService.Store.Db.Repositories/*.csproj ./src/Infrastructure/Swipty.MainService.Store.Db.Repositories/

COPY src/Web/Web/*.csproj ./src/Web/Web/
COPY src/Web/Web.Contracts/*.csproj ./src/Web/Web.Contracts/

COPY tests/UnitTests/UnitTests/*.csproj ./tests/UnitTests/UnitTests/
COPY tests/IntegrationsTests/IntegrationsTests/*.csproj ./tests/IntegrationsTests/IntegrationsTests/

RUN dotnet restore

COPY . .
RUN dotnet build -c Release --no-restore

FROM build AS publish
RUN dotnet publish -c Release --no-restore -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=publish /app/out ./

ENTRYPOINT ["dotnet", "Web.dll"]