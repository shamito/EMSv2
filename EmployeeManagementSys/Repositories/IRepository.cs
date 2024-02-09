using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;

namespace EmployeeManagementSys.Repositories
{
    public interface IRepository<T> where T : class, IEmployeeRepository
    {
        Task<List<T>> GetAllEmployees();
        Task<T> GetEmployee(int id);
        Task<T> AddEmployee(T entity);
        Task<T> UpdateEmployee(T entity);
        Task<T> DeleteEmployee(int id);
    }
}
