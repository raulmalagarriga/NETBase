# NETBase

Template for a ASP Net core API, EF Core and PostgreSQL with a simple implementation of Unit of Work design pattern | Code first approach

## Nuget Packages
Microsoft.EntityFrameworkCore.Design

Microsoft.EntityFrameworkCore.Tools

Newtonsoft.Json

Npgsql.EntityFrameworkCore.PostgreSQL

Npgsql.EntityFrameworkCore.PostgreSQL.Design

Swashbuckle.AspNetCore

Swashbuckle.AspNetCore.Annotations

## Environments variables guide (.appsetting.json)

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Host=<your-ip>;Username=<your-username>;Password=<your-password>;Database=<your-db-name>"
  },
  "AllowedHosts": "*",
  "Kestrel": {
    "Endpoints": {
      "Http": {
        "Url": "http://localhost:5000"
      },
      "Https": {
        "Url": "https://localhost:5001"
      }
    }
  }
}
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.
