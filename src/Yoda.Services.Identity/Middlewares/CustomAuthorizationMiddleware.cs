using System.Net;

namespace Yoda.Services.Customer.Middlewares;

public class CustomAuthorizationMiddleware
{
    private readonly RequestDelegate _next;

    public CustomAuthorizationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Response.HasStarted)
        {
            if (context.Request.Headers.TryGetValue("Authorization", out var bearerToken))
            {
                var token = bearerToken.ToString().Split(' ')[1];
                if (token != "abc")
                {
                    context.Response.ContentType = "application/Json";
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await context.Response.StartAsync();
                }
            }
        }
        else
        {
            await _next.Invoke(context);
        }
    }
}
