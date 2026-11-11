# BlazorApp - Clean Architecture Solution

A modern Blazor WebAssembly application following clean architecture principles.

## Project Structure

```
BlazorApp.sln
├── src/
│   ├── Presentation/
│   │   └── BlazorApp.Web/          # Blazor WebAssembly UI
│   ├── Application/
│   │   └── BlazorApp.Application/  # Business logic and services
│   ├── Domain/
│   │   └── BlazorApp.Domain/       # Domain entities and interfaces
│   └── Infrastructure/
│       └── BlazorApp.Infrastructure/ # Data access and external services
```

## Layers

### Presentation Layer (BlazorApp.Web)
- Blazor components and pages
- User interface and interaction logic
- References: Application layer

### Application Layer (BlazorApp.Application)
- Business logic and use cases
- Application services
- DTOs and mappers
- References: Domain and Infrastructure layers

### Domain Layer (BlazorApp.Domain)
- Core business entities
- Domain models and rules
- No external dependencies
- References: None (only .NET framework)

### Infrastructure Layer (BlazorApp.Infrastructure)
- Data access (repositories)
- External service integrations
- Configuration and utilities
- References: Domain layer

## Getting Started

1. Open `BlazorApp.sln` in Visual Studio
2. Restore NuGet packages
3. Run the web project (BlazorApp.Web)
4. Navigate to the application in your browser

## Dependencies

- .NET 8.0 or later
- ASP.NET Core Blazor WebAssembly 8.0

## Key Principles

- **Separation of Concerns**: Each layer has a specific responsibility
- **Dependency Inversion**: High-level modules don't depend on low-level modules
- **Testability**: Layers can be tested independently
- **Maintainability**: Clear structure makes code easier to understand and modify
