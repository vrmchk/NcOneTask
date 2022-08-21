using Artsofte.Models.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Artsofte.Filters;

public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            var errorsInModelState = context.ModelState
                .Where(x => x.Value != null && x.Value.Errors.Count > 0)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value!.Errors.Select(x => x.ErrorMessage).ToArray());
            var errorResponse = new ErrorResponse();

            foreach ((string causeOfError, string[] messages) in errorsInModelState)
            {
                errorResponse.Errors.AddRange(messages.Select(m => new ErrorModel
                {
                    CauseOfError = causeOfError,
                    Message = m
                }));
            }

            context.Result = new BadRequestObjectResult(errorResponse);
            return;
        }

        await next();
    }
}