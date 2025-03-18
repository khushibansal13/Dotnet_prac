# .NET Project

Welcome to your .NET project! This repository contains a Web API built with .NET and follows best practices for API development.

## 📁 Project Structure

- `dotnet_prac/api` - Practice and sample code for learning and exploring .NET concepts.
- `Projects/` - Additional projects, tools, or supporting applications.
- `WebAPI.sln` - Solution file to manage the overall project in Visual Studio.

## 🚀 Getting Started

Follow these steps to set up and run the project locally.

### Prerequisites
- .NET 8.0 or later
- SQL Server (if using a database)
- Visual Studio or Visual Studio Code
- Git

### Installation

1. Clone the repository:
    ```bash
    git clone <repository-url>
    cd .NET
    ```

2. Navigate to the API directory:
    ```bash
    cd api
    ```

3. Install dependencies:
    ```bash
    dotnet restore
    ```

4. Configure the database connection string in `appsettings.json`.

5. Apply migrations (if using Entity Framework):
    ```bash
    dotnet ef database update
    ```

6. Run the application:
    ```bash
    dotnet run
    ```

## 🛠️ Useful Commands

- Build the solution: `dotnet build`
- Run the application: `dotnet run`
- Test the application: `dotnet test`
- Create migrations: `dotnet ef migrations add <MigrationName>`



