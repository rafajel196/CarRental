using CarRental.Application.Authentication;
using CarRental.Application.Authorization;
using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Functions.CarAddresses.Commands.AddCarAddress;
using CarRental.Application.Functions.CarAddresses.Commands.UpdateCarAddress;
using CarRental.Application.Functions.Cars.Commands.AddCar;
using CarRental.Application.Functions.Cars.Commands.UpdateCar;
using CarRental.Application.Functions.Rentals.Command.RentCar;
using CarRental.Application.Functions.Users.Commands.RegisterUser;
using CarRental.Application.Functions.Users.Commands.UpdateUser;
using CarRental.Application.Middleware;
using CarRental.Domain.Entities;
using CarRental.Persistance.EF;
using CarRental.Persistance.EF.Repositories;
using CarRental.Persistance.EF.SeedData;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using CarRental.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

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

            builder.Services
                .AddApplication()
                .AddPersistance(builder.Configuration);


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.MapGet("cars", async (CarRentalContext db) =>
            {
                var cars = await db.Cars.ToListAsync();

                return cars;
            });

            app.Run();
        }
    }
}