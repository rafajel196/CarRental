using CarRental.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            catch (CannotRentThePremiumCarException cannotRentThePremiumCarException)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync(cannotRentThePremiumCarException.Message);
            }
            catch (InvalidEmailOrPasswordException invalidEmailOrPasswordException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(invalidEmailOrPasswordException.Message);
            }
            catch (UserNotFoundException userNotFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(userNotFoundException.Message);
            }
            catch (CarAddressNotFoundException carAddressNotFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(carAddressNotFoundException.Message);
            }
            catch (CarNotFoundException carNotFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(carNotFoundException.Message);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}
