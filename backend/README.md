## О проекте
Librarian .....

Документация:
...

## Проекты для запуска
#### Web
Запустит HTTP-сервер
#### Migrate
Утилита миграции БД.

Создание миграции схемы
```shell
dotnet ef migrations add NameOfNewMigration --project src\Store.Migrations --context ResourcesContext
```

Применение миграции схемы
```shell
# из исходников
dotnet run --project src\Web.Web --just-migrate-db

# из бинарников
dotnet Platform.Resources.Web.Web.dll --just-migrate-db
```

```

