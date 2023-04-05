using CarRental.Application.Authentication;
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
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;

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

            var authenticationSettings = new AuthenticationSettings();
            builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
            builder.Services.AddSingleton(authenticationSettings);
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
                };
            });

            builder.Services.AddControllers();
            builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICarAddressRepository, CarAddressRepository>();
            builder.Services.AddScoped<IRentalRepository, RentalRepository>();

            builder.Services.AddScoped<ErrorHandlingMiddleware>();
            builder.Services.AddScoped<IValidator<AddCarCommand>, AddCarCommandValidator>();
            builder.Services.AddScoped<IValidator<UpdateCarCommand>, UpdateCarCommandValidator>();
            builder.Services.AddScoped<IValidator<AddCarAddressCommand>, AddCarAddressCommandValidator>();
            builder.Services.AddScoped<IValidator<UpdateCarAddressCommand>, UpdateCarAddressCommandValidator>();
            builder.Services.AddScoped<IValidator<UpdateUserCommand>, UpdateUserCommandValidator>();
            builder.Services.AddScoped<IValidator<RegisterUserCommand>, RegisterUserCommandValidator>();
            builder.Services.AddScoped<IValidator<RentCarCommand>, RentCarCommandValidator>();


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