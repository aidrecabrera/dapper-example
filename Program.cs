using MySql.Data.MySqlClient;
using Dapper;

namespace Dapper_Introduction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=dapper;Uid=aidrecabrera;Pwd=aidrecabrera;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            var employee = new Employee
            {
                Name = "Aidre",
                Age = 30,
                Salary = 130000
            };

            string insertQuery = "INSERT INTO employees (Name, Age, Salary) VALUES (@Name, @Age, @Salary)";

            connection.Execute(insertQuery, employee);

            string selectQuery = "SELECT * FROM employees";

            List<Employee> employees = connection.Query<Employee>(selectQuery).ToList();

            employee.Salary = 140000;
            string updateQuery = "UPDATE employees SET Salary = @Salary WHERE Id = @Id";
            connection.Execute(updateQuery, employee);

            int employeeIdToDelete = 1;
            string deleteQuery = "DELETE FROM employees WHERE Id = @Id";
            connection.Execute(deleteQuery, new { Id = employeeIdToDelete });
        }
    }
}
