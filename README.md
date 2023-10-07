# Employees - Dapper Example Program

This is a simple C# program that demonstrates the usage of [Dapper](https://github.com/DapperLib/Dapper), a micro ORM (Object-Relational Mapping) for .NET, by performing basic database operations with a MySQL database. In this program, we create an `Employee` class and use Dapper to perform CRUD (Create, Read, Update, Delete) operations on a MySQL database table named `employees`.

## Prerequisites

Before running this program, make sure you have the following prerequisites:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [MySQL Server](https://dev.mysql.com/downloads/installer/) with a database named `dapper`.
- MySQL user credentials (`Uid` and `Pwd`) with appropriate permissions to access the database.

## Installation and Setup

1. Clone or download this repository to your local machine.
2. Open the project in your preferred C# IDE or text editor.

## Configuration

In the `Program.cs` file, you will find a `connectionString` variable. Modify this variable to specify the connection details for your MySQL database:

```csharp
string connectionString = "Server=127.0.0.1;Port=3306;Database=dapper;Uid=your_username;Pwd=your_password;";
```

Replace `your_username` and `your_password` with your MySQL user credentials.

## Database Schema

The MySQL database `dapper` used in this program contains a single table named `employees`. Here's the schema for the `employees` table:

```sql
CREATE TABLE employees (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Age INT NOT NULL,
    Salary DECIMAL(10, 2) NOT NULL
);
```

- `Id`: A unique identifier for each employee, automatically incremented.
- `Name`: The name of the employee (a string).
- `Age`: The age of the employee (an integer).
- `Salary`: The salary of the employee (a decimal number).

## Usage

This program performs the following CRUD operations on the `employees` table:

1. **Creating Data (C - Create)**: It inserts an employee record into the `employees` table with a name, age, and salary. You can customize the data in the `Employee` object:

   ```csharp
   var employee = new Employee
   {
       Name = "Aidre",
       Age = 30,
       Salary = 130000
   };
   ```

2. **Reading Data (R - Read)**: It retrieves all employee records from the `employees` table and stores them in a list of `Employee` objects.

   ```csharp
   string selectQuery = "SELECT * FROM employees";
   List<Employee> employees = connection.Query<Employee>(selectQuery).ToList();
   ```

3. **Updating Data (U - Update)**: It updates the details of an existing employee in the `employees` table. Modify the properties of the `Employee` object and execute an update query to apply changes.

   ```csharp
   // Example: Updating the salary of an employee
   employee.Salary = 140000;
   string updateQuery = "UPDATE employees SET Salary = @Salary WHERE Id = @Id";
   connection.Execute(updateQuery, employee);
   ```

4. **Deleting Data (D - Delete)**: It deletes an employee record from the `employees` table based on the employee's `Id`.

   ```csharp
   // Example: Deleting an employee by Id
   int employeeIdToDelete = 1;
   string deleteQuery = "DELETE FROM employees WHERE Id = @Id";
   connection.Execute(deleteQuery, new { Id = employeeIdToDelete });
   ```

## Running the Program

1. Build the project using your IDE or by running `dotnet build` in the project directory.
2. Run the program using your IDE or by executing `dotnet run` in the project directory.

That's all! :)
