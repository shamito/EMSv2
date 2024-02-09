using EMSv2.Data;
using EMSv2.Dtos;
using EMSv2.Interfaces;
using EMSv2.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EMSv2.Repository
{
    public class EmployeeDetailsRepository : IEmployeeDetailsRepository
    {
        private readonly ApplicationDBContext _context;
        public EmployeeDetailsRepository(ApplicationDBContext context) 
        {
            _context = context;
        }
        public async Task<List<EmployeeDetails>> GetEmployees()
        {
            return await _context.EmployeeDetails.ToListAsync();
        }

        public async Task<EmployeeDetails> AddEmployee(EmployeeDetails employeeModel)
        {
            await _context.EmployeeDetails.AddAsync(employeeModel);
            await _context.SaveChangesAsync();
            return employeeModel;
        }

        public async Task<EmployeeDetails?> DeleteEmployeeByIdAsync(int id)
        {
            var employeeModel = await _context.EmployeeDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (employeeModel == null)
            {
                return null;
            }
            
            _context.EmployeeDetails.Remove(employeeModel);
            await _context.SaveChangesAsync();
            return employeeModel;
        }

        public async Task<EmployeeDetails?> GetEmployeeByIdAsync(int id)
        {
            return await _context.EmployeeDetails.FindAsync(id);
        }

        public async Task<EmployeeDetails?> UpdateEmployee(int id, UpdateEmployeeRequestDto employeeDto)
        {
            var existingEmployee = await _context.EmployeeDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (existingEmployee == null)
            {
                return null;
            }

            existingEmployee.FirstName = employeeDto.FirstName;
            existingEmployee.MiddleName = employeeDto.MiddleName;
            existingEmployee.LastName = employeeDto.LastName;

            await _context.SaveChangesAsync();

            return existingEmployee;
        }
    }
}
