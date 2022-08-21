using Artsofte.BLL.Exceptions;
using Artsofte.Models.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Artsofte.Filters;

public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var ex = context.Exception;
        string message = ex.Message;

        IActionResult actionResult = ex switch
        {
            EmployeeDoesntExistException employeeEx => new BadRequestObjectResult(new ErrorResponse
            {
                Errors = new List<ErrorModel>
                    {new ErrorModel {CauseOfError = employeeEx.CauseOfError, Message = message}}
            }),
            DepartmentDoesntExistException departmentEx => new BadRequestObjectResult(new ErrorResponse
            {
                Errors = new List<ErrorModel>
                    {new ErrorModel {CauseOfError = departmentEx.CauseOfError, Message = message}}
            }),
            ProgrammingLanguageDoesntExistException languageEx => new BadRequestObjectResult(new ErrorResponse
            {
                Errors = new List<ErrorModel>
                    {new ErrorModel {CauseOfError = languageEx.CauseOfError, Message = message}}
            }),
            _ => new ObjectResult(new ErrorResponse
            {
                Errors = new List<ErrorModel> {new ErrorModel {CauseOfError = "General Error", Message = message}}
            })
            {
                StatusCode = 500
            }
        };
        context.ExceptionHandled = true;
        context.Result = actionResult;
    }
}