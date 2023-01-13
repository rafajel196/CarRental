using Microsoft.EntityFrameworkCore;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistance.EF
{
    internal class CarRentalContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
    }
}
