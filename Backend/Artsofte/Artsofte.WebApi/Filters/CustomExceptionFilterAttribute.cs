using Artsofte.BLL.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Artsofte.Filters;

public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly IWebHostEnvironment _hostEnvironment;

    public CustomExceptionFilterAttribute(IWebHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }

    public override void OnException(ExceptionContext context)
    {
        var ex = context.Exception;
        string message = ex.Message;
        string stackTrace = string.Empty;
        if (_hostEnvironment.IsDevelopment())
            stackTrace = context.Exception.StackTrace ?? string.Empty;

        IActionResult actionResult = ex switch {
            EmployeeDoesntExistException => new BadRequestObjectResult(new {
                Error = "Employee issue", Message = message, StackTrace = stackTrace
            }),
            DepartmentDoesntExistException => new BadRequestObjectResult(new {
                Error = "Department issue", Message = message, StackTrace = stackTrace
            }),
            ProgrammingLanguageDoesntExistException => new BadRequestObjectResult(new {
                Error = "Programming language issue", Message = message, StackTrace = stackTrace
            }),
            _ => new ObjectResult(new {Error = "General error", Message = message, StackTrace = stackTrace}) {
                StatusCode = 500
            }
        };
        context.ExceptionHandled = true;
        context.Result = actionResult;
    }
}