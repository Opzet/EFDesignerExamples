# Event Sourcing App Structure

A clean and automated way to update Event Sourcing documentation for your event sourcing application.


## Try .NET for Interactive Documentation for .NET Core Applications

``` 

dotnet tool install -g --add-source "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json" Microsoft.dotnet-try

```

see https://github.com/dotnet/try/blob/main/DotNetTryLocal.md

Try .NET is an interactive documentation generator for .NET Core

 --version 1.0.19266.1 Updating to the latest version of the tool is easy just run the command below dotnet tool update -g dotnet-try * Navigate to the Samples directory of this repository and, type the following dotnet try. dotnet try global tool, image * This will launch the browser. Interactive .NET documentation, image

Try .NET is now Open Source on GitHub! interactive .NET documentation, and workshop you create.

dotnet try verify is a compiler for your documentation. 

With this command, you can make sure that every code snippet will work and is in sync with the backing project. 

The goal of dotnet try verify is to validate that your documentation works as intended.


```
UserRegistration/
├── Domain/
│   ├── Events/
│   │   ├── IEvent.cs
│   │   ├── UserRegisteredEvent.cs
│   ├── Models/
│   │   ├── User.cs
├── Infrastructure/
│   ├── EventStore.cs
│   ├── EventDispatcher.cs
├── Services/
│   ├── UserService.cs
├── Program.cs
```

## Automated Documentation

Automated documentation updates are implemented by embedding metadata generation in C# code using custom attributes and an event schema registry.

The EventCatalog SDK is an NPX tool that interprets .md files.

Require a generator to parse C# code and produce the necessary markdown documentation,

A C# code parser that extracts metadata from custom attributes and generates markdown documentation.


### Steps

1. **Define Custom Attributes**: Custom attributes are used to annotate events with metadata.
2. **Event Schema Registry**: A registry is implemented to store and retrieve event schemas.
3. **Integrate with EventCatalog SDK**: The EventCatalog SDK is used to generate and update documentation.

### Example

The `UserRegisteredEvent` is annotated with metadata, and the `EventSchemaRegistry` retrieves the schema to update the documentation using the EventCatalog SDK.

```csharp
[EventMetadata("UserRegisteredEvent", "Event triggered when a user registers.")]
public class UserRegisteredEvent : IEvent { // Event properties and constructor }
```

This setup ensures that your event schemas are automatically documented and kept up-to-date.
