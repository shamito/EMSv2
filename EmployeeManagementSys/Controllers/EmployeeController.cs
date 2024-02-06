using EmployeeManagementSys.Filters.ActionFilters;
using EmployeeManagementSys.Filters.ExceptionFilters;
using EmployeeManagementSys.Models;
using EmployeeManagementSys.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSys.Controllers;

[ApiController]
[Route("employee")]
public class EmployeeController : Controller
{

    [HttpGet]
    public IActionResult GetEmployees()
    {
        return Ok(Test_EmployeeRepository.GetEmployees());
    }

    [HttpGet("{id}")]
    [Emp_IdValidationFilter]
    public IActionResult GetEmployeeById(int id)
    {

        return Ok(Test_EmployeeRepository.GetEmployeeById(id));
    }

    [HttpPost]
    [Emp_DetailsValidationFilter]
    public IActionResult AddEmployee([FromBody] Employee employee)
    {
        Test_EmployeeRepository.AddEmployee(employee);

        return CreatedAtAction(nameof(GetEmployeeById),
            new { id = employee.Id },
            employee);
    }

    [HttpPut("{id}")]
    [Emp_IdValidationFilter]
    [Emp_UpdateValidationFilter]
    [Emp_HandleUpdateFilter]
    public IActionResult UpdateEmployee(int id, Employee employee)
    {

        Test_EmployeeRepository.UpdateEmployee(employee);


        return Ok($"Employeed#:{id} has been updated ");
    }

    [HttpDelete("{id}")]
    [Emp_IdValidationFilter]
    public IActionResult DeleteEmployee(int id)
    {
        var employee = Test_EmployeeRepository.GetEmployeeById(id);
        Test_EmployeeRepository.DeleteEmployee(id);

        return Ok($"Deleted #:{id} ");
    }
}