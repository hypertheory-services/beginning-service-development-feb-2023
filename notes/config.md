Hierarchical Configuration in .NET Core


When we ask for a value from the configuration API, it looks (by default) in the following places.

[From Microsoft](https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration)

Command-line arguments using the Command-line configuration provider.
Environment variables using the Environment Variables configuration provider.
App secrets when the app runs in the Development environment.
appsettings.Environment.json using the JSON configuration provider. For example, appsettings.Production.json and appsettings.Development.json.
appsettings.json using the JSON configuration provider.
