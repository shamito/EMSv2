using EmployeeManagementSys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSys.Repositories;

public interface IEmployeeRepository
{
    ActionResult<IEnumerable<Employee>> GetEmployees();
    Task GetEmployeeById(int id);
    Task AddEmployee(Employee employee);
    Task UpdateEmployee(Employee employee);
    Task DeleteEmployee(int id);
}
