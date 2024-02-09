using EMSv2.Dtos;
using EMSv2.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMSv2.Interfaces
{
    public interface IEmployeeDetailsRepository
    {
        Task <List<EmployeeDetails>> GetEmployees();
        Task<EmployeeDetails?> GetEmployeeByIdAsync(int id);
        Task<EmployeeDetails> AddEmployee(EmployeeDetails employeeModel);
        Task<EmployeeDetails?> UpdateEmployee(int id, UpdateEmployeeRequestDto employeeDto);
        Task<EmployeeDetails?> DeleteEmployeeByIdAsync(int id);
    }
}
