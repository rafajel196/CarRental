using CarRental.Application.Functions.CarAddresses.Commands.AddCarAddress;
using CarRental.Application.Functions.CarAddresses.Commands.UpdateCarAddress;
using CarRental.Application.Functions.Cars.Commands.AddCar;
using CarRental.Application.Functions.Cars.Commands.UpdateCar;
using CarRental.Application.Functions.Rentals.Command.RentCar;
using CarRental.Application.Functions.Users.Commands.RegisterUser;
using CarRental.Application.Functions.Users.Commands.UpdateUser;
using CarRental.Application.Middleware;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<IValidator<AddCarCommand>, AddCarCommandValidator>();
            services.AddScoped<IValidator<UpdateCarCommand>, UpdateCarCommandValidator>();
            services.AddScoped<IValidator<AddCarAddressCommand>, AddCarAddressCommandValidator>();
            services.AddScoped<IValidator<UpdateCarAddressCommand>, UpdateCarAddressCommandValidator>();
            services.AddScoped<IValidator<UpdateUserCommand>, UpdateUserCommandValidator>();
            services.AddScoped<IValidator<RegisterUserCommand>, RegisterUserCommandValidator>();
            services.AddScoped<IValidator<RentCarCommand>, RentCarCommandValidator>();

            return services;
        }
    }
}
