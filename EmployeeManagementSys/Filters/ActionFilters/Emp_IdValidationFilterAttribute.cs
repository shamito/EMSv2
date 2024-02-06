using EmployeeManagementSys.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagementSys.Filters.ActionFilters
{
    public class Emp_IdValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var EmpId = context.ActionArguments["id"] as int?;
            if (EmpId.HasValue)
            {
                if (EmpId.Value <= 0)
                {
                    context.ModelState.AddModelError("Id", "EmployeeId is invalid.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else if (!Test_EmployeeRepository.EmployeeExist(EmpId.Value))
                {
                    context.ModelState.AddModelError("Id", "EmployeeId doesn't exist.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}
