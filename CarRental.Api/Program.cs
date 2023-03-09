using CarRental.Application.Contracts.Persistance;
using CarRental.Persistance.EF;
using CarRental.Persistance.EF.Repositories;
using CarRental.Persistance.EF.SeedData;
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
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<ICarRepository, CarRepository>();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            //app.UseAuthorization();
            //app.UseAuthentication();

            //app.UseCors("AllowAlls");

            app.MapControllers();

            app.MapGet("data", async (CarRentalContext db) =>
            {
                var cars = await db.Cars.ToListAsync();

                return cars;
            });

            app.Run();
        }
    }
}