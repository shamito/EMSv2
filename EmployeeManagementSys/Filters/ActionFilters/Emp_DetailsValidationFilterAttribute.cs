using EmployeeManagementSys.Models;
using EmployeeManagementSys.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagementSys.Filters.ActionFilters
{
    public class Emp_DetailsValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var employee = context.ActionArguments["employee"] as Employee;

            if (employee == null)
            {
                context.ModelState.AddModelError("Id", "Employee Object is null.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {

                var employeeExist = Test_EmployeeRepository.GetEmployeeDetails(employee.FirstName, employee.MiddleName, employee.LastName);
                if (employeeExist != null)
                {
                    context.ModelState.AddModelError("employee", "Employee already exist.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }
        }
    }
}
