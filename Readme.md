# Create migration in the PMC with EF Core

For instance:

```
dotnet ef migrations add Cinemas --project Films.Core.DomainServices --startup-project Films.Api
```

To apply the migration:

```
Update-Database
```