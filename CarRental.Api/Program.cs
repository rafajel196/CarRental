using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Functions.CarAddresses.Commands.AddCarAddress;
using CarRental.Application.Functions.CarAddresses.Commands.UpdateCarAddress;
using CarRental.Application.Functions.Cars.Commands.AddCar;
using CarRental.Application.Functions.Cars.Commands.UpdateCar;
using CarRental.Application.Functions.Users.Commands.AddUser;
using CarRental.Application.Functions.Users.Commands.UpdateUser;
using CarRental.Application.Middleware;
using CarRental.Persistance.EF;
using CarRental.Persistance.EF.Repositories;
using CarRental.Persistance.EF.SeedData;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CarRental.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<CarRentalContext>(
                    option => option.UseSqlServer(builder.Configuration.GetConnectionString("CarRentalConnectionString"))
                );

            builder.Services.AddControllers();
            builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICarAddressRepository, CarAddressRepository>();

            builder.Services.AddScoped<ErrorHandlingMiddleware>();
            builder.Services.AddScoped<IValidator<AddCarCommand>, AddCarCommandValidator>();
            builder.Services.AddScoped<IValidator<UpdateCarCommand>, UpdateCarCommandValidator>();
            builder.Services.AddScoped<IValidator<AddCarAddressCommand>, AddCarAddressCommandValidator>();
            builder.Services.AddScoped<IValidator<UpdateCarAddressCommand>, UpdateCarAddressCommandValidator>();
            builder.Services.AddScoped<IValidator<AddUserCommand>, AddUserCommandValidator>();
            builder.Services.AddScoped<IValidator<UpdateUserCommand>, UpdateUserCommandValidator>();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseHttpsRedirection();
            app.UseRouting();
            //app.UseAuthentication();
            //app.UseAuthorization();

            //app.UseCors("AllowAlls");

            app.MapControllers();

            app.MapGet("cars", async (CarRentalContext db) =>
            {
                var cars = await db.Cars.ToListAsync();

                return cars;
            });

            app.Run();
        }
    }
}