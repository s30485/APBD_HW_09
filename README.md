to runm the app correctly, in appsettings you should include a connection string to a database, whether its a local db like in docker, or a remote one - it's up to you.

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "YOUR-CONNECTION-STRING"
  }
}
