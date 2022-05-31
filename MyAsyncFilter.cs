using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiTest;

public class MyAsyncFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context, ActionExecutionDelegate next)
    {
        String a = context.HttpContext.Request.Path;
        String b = a;
        // Do something before the action executes.
        await next();
        // Do something after the action executes.
    }
}
