using CarRental.Persistance.EF;
using Microsoft.EntityFrameworkCore;

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

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}