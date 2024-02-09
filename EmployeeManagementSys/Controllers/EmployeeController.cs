﻿using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;
using EmployeeManagementSys.Filters.ActionFilters;
using EmployeeManagementSys.Models;
using EmployeeManagementSys.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSys.Controllers;

[ApiController]
[Route("employee")]

public abstract class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _repo;

    public EmployeeController(IEmployeeRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetEmployeesValues()
    {
        var employee = _repo.GetEmployees();
        return Ok(employee);
    }

    [HttpGet("{id}")]
    public ActionResult GetEmployeeById(int id)
    {
        return Ok(_repo.GetEmployeeById(id));
    }

    [HttpPost]
    [Emp_IdValidationFilter]
    public async Task<OkObjectResult> AddEmployee([FromBody] Employee employee)
    {

        _repo.AddEmployee(employee);
        return Ok(employee);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateEmployee(Employee employee)
    {
        if (employee == null)
        {
            return NotFound("Getting null for student");
        }

        _repo.UpdateEmployee(employee);
        return Ok("Value Updated");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEmployee(int id)
    {
        if (id == null)
        {
            return NotFound("Getting null for student id");
        }
        _repo.DeleteEmployee(id);
        return Ok("Value Deleted");
    }
}