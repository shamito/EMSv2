using EmployeeManagementSys.Models;
using System.ComponentModel;

namespace EmployeeManagementSys.Repositories
{
    public class Test_EmployeeRepository
    {
        private static List<Employee> employees = new List<Employee>()
        {
            new Employee {Id = 1, FirstName = "John", MiddleName = "A", LastName = "Doe"},
            new Employee {Id = 2, FirstName = "Jane", MiddleName = "B", LastName = "Smith"},
            new Employee {Id = 3, FirstName = "Michael", MiddleName = "C", LastName = "Johnson"},
            new Employee {Id = 4, FirstName = "Emily", MiddleName = "", LastName = "Brown"}
        };


        public static List<Employee> GetEmployees()
        {
            return employees;
        }

        public static bool EmployeeExist(int id)
        {
            return employees.Any(x => x.Id == id);
        }

        public static Employee? GetEmployeeById(int id)
        {
            return employees.FirstOrDefault(x => x.Id == id);
        }

        public static Employee? GetEmployeeDetails(String FirstName, String MiddleName, String LastName)
        {
            return employees.FirstOrDefault(x =>
                !string.IsNullOrWhiteSpace(FirstName) &&
                !string.IsNullOrWhiteSpace(x.FirstName) &&
                x.FirstName.Equals(FirstName, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(LastName) &&
                !string.IsNullOrWhiteSpace(x.LastName) &&
                x.LastName.Equals(LastName, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(MiddleName) &&
                !string.IsNullOrWhiteSpace(x.MiddleName) &&
                x.MiddleName.Equals(MiddleName, StringComparison.OrdinalIgnoreCase)
            );
        }

        public static void AddEmployee(Employee employee)
        {
           int maxId = employees.Max(x => x.Id);
            employee.Id = maxId + 1;

            employees.Add(employee);
        }

        public static void UpdateEmployee(Employee employee)
        {
            var employeeToUpdate = employees.First(x => x.Id == employee.Id);
            employeeToUpdate.FirstName = employee.FirstName;
            employeeToUpdate.MiddleName = employee.MiddleName;
            employeeToUpdate.LastName = employee.LastName;
        }

        public static void DeleteEmployee(int id)
        {
            var employee = GetEmployeeById(id);
            if (employee != null)
            {
                employees.Remove(employee);
            }
        }
    }
}
