using CarRental.Application.Middleware;
using CarRental.Persistance.EF;
using Microsoft.EntityFrameworkCore;
using CarRental.Application;


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