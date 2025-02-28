# .NET Web API Project

## Overview
This is a .NET Web API project built with .NET 8.0.406, designed to create scalable and maintainable RESTful APIs using Entity Framework Core (EF Core) and SQL Server. It provides a foundation for building backend services with support for traditional controllers, DTOs, and custom mappers.

## Features
- **API Structure**: Supports both minimal and traditional API approaches (controllers).
- **Database Integration**: Uses EF Core for database persistence with SQL Server.
- **Data Transfer**: Implements DTOs for secure and controlled data exchange.
- **Testing**: Includes REST Client support for API testing.

## Getting Started

### Prerequisites
- .NET SDK 8.0 or higher (`dotnet --version`).
- SQL Server (or SQL Server Express) installed.
- Visual Studio Code or Visual Studio (optional).

### Installation
1. Clone the repository:
   ```bash
   git clone <your-repo-url>
   cd api
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Update `appsettings.json` with your SQL Server connection string:
   ```json
   {
       "ConnectionStrings": {
           "DefaultConnection": "Server=localhost;Database=YourDB;Trusted_Connection=True;TrustServerCertificate=True;"
       }
   }
   ```

4. Apply EF Core migrations to create the database:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

5. Run the application:
   ```bash
   dotnet run
   ```
   Or for hot reload during development:
   ```bash
   dotnet watch run
   ```

## API Endpoints
- Define your endpoints in `Controllers/` (e.g., `GET /api/your-endpoint`, `POST /api/your-endpoint`).
- Use the `api.http` file to test endpoints with the REST Client extension in VS Code.

## Dependencies
- `Microsoft.EntityFrameworkCore.SqlServer` (EF Core for SQL Server).
- `AutoMapper` (optional, for entity-DTO mapping).



