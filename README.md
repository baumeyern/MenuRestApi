# Menu Items API

This API provides full CRUD (Create, Read, Update, Delete) functionality for managing menu items. Use it to manage a collection of items with properties such as name, description, price, and category.
## Table of Contents

- [Design Features](#design-features)
- [Features](#functional-features)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Example Request](#example-request)

---

## Design Features
- **Dependency Injection**: Facilitates service lifetime management and improves testability with DI.
- **Entity Framework Core**: Handles database operations, migrations, and queries with EF Core.
- **MVC Design Pattern**:  Clean separation of responsibilities between models, API endpoints (views), and controllers.
- **Swagger/OpenAPI**: Built-in Swagger UI for easy API testing and comprehensive documentation.
- **SOLID Principles**: Follows SOLID principles to promote clean, maintainable, and scalable code.
- **Clean Code**: Follows clean code guidelines for maintainable and easy-to-read code.

## Functional Features
- Supports full CRUD operations on menu items in a restaurant-style database.
- **Create** new menu items.
- **Read** menu items (single or all).
- **Update** existing menu items.
- **Delete** menu items.

## Getting Started

To set up and run the project locally:

1. **Clone the Repository**:
    ```bash
    git clone https://github.com/baumeyern/MenuAPI.git
    ```

2. **Install Dependencies** (if using .NET Core):
    ```bash
    dotnet restore
    ```

3. **Set up the database (SQL Server):**:
    - Update your appsettings.json with your local database connection string.
    - Run migrations to create the database:
       ```bash
       dotnet ef database update

4. **Run the project:**:
   ```bash
   dotnet run

5. **Swagger**:
    Once the API is running, you can explore the API documentation and test endpoints using Swagger at `http://localhost:5000/swagger`.

## API Endpoints


### Endpoints

#### Get All Menu Items
- **GET** `/api/MenuItem`
- **Description**: Retrieves all menu items.

#### Get a Menu Item by ID
- **GET** `/api/MenuItem/{id}`
- **Description**: Retrieves a specific menu item by its unique ID.

#### Create a New Menu Item
- **POST** `/api/MenuItem`
- **Description**: Creates a new menu item.
- **Body**: JSON object representing the new menu item.

#### Update an Existing Menu Item
- **PUT** `/api/MenuItem/{id}`
- **Description**: Updates an existing menu item by ID.
- **Body**: JSON object representing the updated menu item.

#### Delete a Menu Item
- **DELETE** `/api/MenuItem/{id}`
- **Description**: Deletes a specific menu item by ID.

## Example Request

### Create a New Menu Item

```http
POST /api/menuitems
{
    "name": "Cheese Pizza",
    "description": "A pizza with 4 cheeses",
    "price": 11.99,
    "category": 1
}
```

## Tests:
- Project has some basic tests, to run them:
  ```bash
  dotnet test
