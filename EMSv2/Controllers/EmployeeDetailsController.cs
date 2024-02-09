using EMSv2.Data;
using EMSv2.Dtos;
using EMSv2.Interfaces;
using EMSv2.Mappers;
using EMSv2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMSv2.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeDetailsController : ControllerBase
    {
        private readonly IEmployeeDetailsRepository _empDetailsRepo;
        public EmployeeDetailsController(IEmployeeDetailsRepository empdetailsRepo) 
        {
            _empDetailsRepo = empdetailsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees() 
        {
            var employees = await _empDetailsRepo.GetEmployees();
            var EmployeeDetailsDto = employees.Select(s => s.ToEmployeeDetailsDto());

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id) 
        { 
            var emp = await _empDetailsRepo.GetEmployeeByIdAsync(id);

            if(emp == null)
            {
                return NotFound();  
            }

            return Ok(emp.ToEmployeeDetailsDto());

        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequestDto addEmployeeDto)
        {
            var employeeModel = addEmployeeDto.ToEmployeeFromCreateDTO();

            await _empDetailsRepo.AddEmployee(employeeModel);

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employeeModel.Id }, employeeModel.ToEmployeeDetailsDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute]int id, [FromBody] UpdateEmployeeRequestDto updateEmpDto)
        {
            var employeeModel = await _empDetailsRepo.UpdateEmployee(id, updateEmpDto);

            if (employeeModel == null)
            {
                return NotFound();
            }

            return Ok(employeeModel.ToEmployeeDetailsDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute]int id)
        {
            var employeeModel = await _empDetailsRepo.DeleteEmployeeByIdAsync(id);

            if(employeeModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
