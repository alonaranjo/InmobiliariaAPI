# InmobiliariaAPI

This is a .NET 8 Minimal API for managing real estate properties. It provides endpoints for creating, retrieving, updating, and deleting properties.

## Architecture

The project follows a clean architecture pattern, with a clear separation of concerns between the different layers:

*   **Endpoints**: Defines the API endpoints using .NET Minimal APIs.
*   **Services**: Contains the business logic for managing properties.
*   **Data**: Implements the data access layer using Entity Framework Core and the repository pattern.
*   **Models**: Defines the data structures, including entities and DTOs.

## Features

*   **CRUD Operations**: Create, Read, Update, and Delete operations for properties.
*   **Pagination**: Paginated responses for retrieving properties.
*   **Validation**: Data validation using data annotations.
*   **Swagger/OpenAPI**: API documentation using Swagger.

## Getting Started

To get the project up and running on your local machine, follow these steps:

### Prerequisites

*   [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Installation

1.  Clone the repository:

    ```bash
    git clone https://your-repository-url/InmobiliariaAPI.git
    ```

2.  Navigate to the project directory:

    ```bash
    cd InmobiliariaAPI
    ```

3.  Restore the dependencies:

    ```bash
    dotnet restore
    ```

4.  Run the application:

    ```bash
    dotnet run
    ```

The application will start on `https://localhost:5001` or `http://localhost:5000` by default. You can access the Swagger UI at `https://localhost:5001/swagger`.

## API Endpoints

The following endpoints are available:

*   `GET /api/properties`: Retrieves a paginated list of properties.
*   `GET /api/properties/{id}`: Retrieves a single property by its ID.
*   `POST /api/properties`: Creates a new property.
*   `PUT /api/properties/{id}`: Updates an existing property.
*   `DELETE /api/properties/{id}`: Deletes a property.
