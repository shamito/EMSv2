using EMSv2.Dtos;
using EMSv2.Models;
using System.Runtime.CompilerServices;

namespace EMSv2.Mappers
{
    public static class EmployeeDetailsMappers
    {
        public static EmployeeDetailsDto ToEmployeeDetailsDto(this EmployeeDetails employeeModels)
        {
            return new EmployeeDetailsDto
            {
                Id = employeeModels.Id,
                FirstName = employeeModels.FirstName,
                MiddleName = employeeModels.MiddleName,
                LastName = employeeModels.LastName
            };
        }

        public static EmployeeDetails ToEmployeeFromCreateDTO(this AddEmployeeRequestDto employeeDto)
        {
            return new EmployeeDetails
            {
                FirstName = employeeDto.FirstName,
                MiddleName = employeeDto.MiddleName,
                LastName = employeeDto.LastName
            };
        }
    }
}
