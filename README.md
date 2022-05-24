# Entity Framework - Fundamentals

- [Entity Framework documentation](https://docs.microsoft.com/en-us/ef/).
- [Code style rule options](https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/code-style-rule-options).
- [Entity Framework Core Succinctly](https://www.syncfusion.com/succinctly-free-ebooks/entity-frame-work-core-succinctly).
- [Code First Data Annotations](https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/data-annotations).
- [Relaciones Ms Docs](https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key).
- [Relaciones EFTutorial](https://www.entityframeworktutorial.net/efcore/configure-one-to-many-relationship-using-fluent-api-in-ef-core.aspx).

## ORM
*O*bject *R*elational *M*apping

*Popular ORM*
- Hibernate (Java)
- Dapper (.NET)
- NHibernate (.NET)
- Django ORM (Python)

## Commands
### Installs nugets packages.
- *Entity Framework Core*: ```dotnet add package Microsoft.EntityFrameworkCore --version 6.0.5```.
- *Database in memory*: ```dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 6.0.5```.
- *Entity Framework for SQL Server*: ```dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.5```.
- *Entity Framework for PostgreSQL*: ```dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 6.0.4```.
- *Entity Framework Tool*: ```dotnet tool install --global dotnet-ef```.
- *Entity Framework Design*: ```dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.5```.

### Entity Framework Migrations
- *Create a migration*: ```dotnet ef migrations add NAME_MIGRATION````.
- *Update database with migrations*: ```dotnet ef database update````.

## Summary
- Entity Framework Core.
- Code-First and Data Annotations Attributes.
- Database in memory and SQL Server.
- Fluent API.