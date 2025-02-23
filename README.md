# Employee Dashboard API

## 📌 Overview
This API is built with **ASP.NET Core** and provides authentication and role-based access to manage employee records.

## 🛠️ Setup and Installation
### 1️⃣ Prerequisites
Ensure you have the following installed:
- **.NET SDK** (version 6.0 or later)
- **SQL Server** (or SQL Server Express)
- **Visual Studio** (or VS Code with C# extension)
- **Postman** (optional for API testing)

### 2️⃣ Configure the Database

#### 🔹 Update `appsettings.json`
Modify the connection string in `appsettings.json` to match your SQL Server configuration:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=EmployeeDashboardDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```
Replace `YOUR_SERVER` with your actual SQL Server instance name.

#### 🔹 Execute SQL Script
Run the `SQLScript.sql` file to set up the database schema and seed initial data.

**Option 1: Using SQL Server Management Studio (SSMS)**
1. Open **SSMS** and connect to your database server.
2. Open `SQLScript.sql` and execute it.

**Option 2: Using .NET CLI**
1. Open a terminal in the project folder.
2. Run the following command to apply the script:
   ```sh
   dotnet ef database update
   ```

If `dotnet ef` is not installed, install it using:
```sh
dotnet tool install --global dotnet-ef
```

---

## 🚀 Running the API
### 1️⃣ Restore Dependencies
```sh
dotnet restore
```

### 2️⃣ Run the API
```sh
dotnet run
```
The API will start on `https://localhost:7125` (or the configured port).

---

## 🔑 Authentication & Roles
The API uses **JWT Authentication** with role-based access:
- **Admin** → Can view & edit employees.
- **User** → Can only view employees.

Use `/api/auth/login` to obtain a token and include it in `Authorization` headers for API requests.

Example:
```json
{
  "username": "admin",
  "password": "admin123"
}
```

Add the token to requests:
```sh
Authorization: Bearer YOUR_TOKEN_HERE
```

---

## 📌 API Endpoints
| HTTP Method | Endpoint | Description |
|------------|----------|-------------|
| **POST** | `/api/auth/login` | Authenticate and get a token |
| **GET** | `/api/employees` | Get the employee list (Admin & User) |
| **PUT** | `/api/employees/{id}` | Update employee name (Admin only) |

---

## 🔥 Notes
- Ensure `SQLScript.sql` is executed before running the API.
- Update **CORS settings** in `Program.cs` if accessing from a frontend.


