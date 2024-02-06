using EmployeeManagementSys.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagementSys.Filters.ExceptionFilters
{
    public class Emp_HandleUpdateFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strEmpId = context.RouteData.Values["id"] as string;
            if (int.TryParse(strEmpId, out int empId))
            {
                if (!Test_EmployeeRepository.EmployeeExist(empId))
                {
                    context.ModelState.AddModelError("Id", "EmployeeId no longer exist ");
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
