using EmployeeManagementSys.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace EmployeeManagementSys.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private EmployeeDBContext _mainContext;
        public EmployeeRepository(EmployeeDBContext context)
        {
            _mainContext = context;
        }

        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            var emp = _mainContext.Employees.ToList();
            return emp; ;
        }

        public async Task AddEmployee(Employee employee)
        {
            if(employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            await _mainContext.Employees.AddAsync(employee);
            await _mainContext.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Employee employee = _mainContext.Employees.FirstOrDefault(x => x.Id == id);

            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            _mainContext.Employees.Remove(employee);
            await _mainContext.SaveChangesAsync();
        }

        public Task GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            Employee existingEmployee = _mainContext.Employees.FirstOrDefault(x => x.Id == employee.Id);

            if (existingEmployee == null)
            {
                throw new ArgumentNullException(nameof(existingEmployee));
            }

            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.MiddleName = employee.MiddleName;

            _mainContext.Attach(existingEmployee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _mainContext.SaveChangesAsync();
        }
    }

}