using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistance.EF.Configuration
{
    public class RentalConfiguration
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.Property(r => r.UserId).IsRequired();
            builder.Property(r => r.CarId).IsRequired();
            builder.Property(r => r.RentDate).HasColumnType("date");
            builder.Property(r => r.ReturnDate).HasColumnType("date");
        }
    }
}
