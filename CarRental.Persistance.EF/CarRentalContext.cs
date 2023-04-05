using Microsoft.EntityFrameworkCore;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using CarRental.Domain.Entities;
using CarRental.Persistance.EF.Configuration;
using CarRental.Persistance.EF.SeedData;

namespace CarRental.Persistance.EF
{
    public class CarRentalContext : DbContext
    {
        public CarRentalContext(DbContextOptions<CarRentalContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CarAddress> CarAddresses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CarConfiguration().Configure(modelBuilder.Entity<Car>());
            new CarAddressConfiguration().Configure(modelBuilder.Entity<CarAddress>());
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new RoleConfiguration().Configure(modelBuilder.Entity<Role>());
            new RentalConfiguration().Configure(modelBuilder.Entity<Rental>());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarRentalContext).Assembly);

            foreach (var item in CarAddressesSeed.Get())
            {
                modelBuilder.Entity<CarAddress>().HasData(item);
            }

            foreach (var item in CarsSeed.Get())
            {
                modelBuilder.Entity<Car>().HasData(item);
            }

            //foreach (var item in UserSeed.Get())
            //{
            //    modelBuilder.Entity<User>().HasData(item);
            //}

            foreach (var item in RoleSeed.Get())
            {
                modelBuilder.Entity<Role>().HasData(item);
            }
        }
    }
}
