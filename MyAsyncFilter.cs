using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ApiTest;

public class MyAsyncFilter : IAsyncAuthorizationFilter
{
    private ILogger<MyAsyncFilter> _logger;

    public MyAsyncFilter(ILogger<MyAsyncFilter> logger)
    {
        this._logger = logger;
    }

    public async Task
    OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        this._logger.LogInformation("IN AUTH: {count}", context.HttpContext.Request.Headers["onx-count"].FirstOrDefault());
        await Task.Delay(100);
    }

}
