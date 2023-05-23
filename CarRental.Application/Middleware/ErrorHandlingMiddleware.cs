using CarRental.Application.Exceptions;
using Microsoft.AspNetCore.Http;


namespace CarRental.Application.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(e, context);
            }
        }
        private async Task HandleExceptionAsync(Exception e, HttpContext context)
        {
            var (statusCode, error) = e switch
            {
                CarNotFoundException => (context.Response.StatusCode = (int)HttpStatusCode.NotFound, context.Response.WriteAsync(e.Message)),
                CarAddressNotFoundException => (context.Response.StatusCode = (int)HttpStatusCode.NotFound, context.Response.WriteAsync(e.Message)),
                UserNotFoundException => (context.Response.StatusCode = (int)HttpStatusCode.NotFound, context.Response.WriteAsync(e.Message)),
                InvalidEmailOrPasswordException => (context.Response.StatusCode = (int)HttpStatusCode.BadRequest, context.Response.WriteAsync(e.Message)),
                CannotRentThePremiumCarException => (context.Response.StatusCode = (int)HttpStatusCode.Forbidden, context.Response.WriteAsync(e.Message)),
                _ => (context.Response.StatusCode = (int)HttpStatusCode.InternalServerError, context.Response.WriteAsync("Something went wrong"))
            };
        }
    }
}
