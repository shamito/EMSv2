using EmployeeManagementSys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagementSys.Filters.ActionFilters
{
    public class Emp_UpdateValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;
            var employee = context.ActionArguments["employee"] as Employee;

            if (id.HasValue && employee != null && id != employee.Id)
            {
                context.ModelState.AddModelError("Id", "EmployeeId is not the same as id.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}
