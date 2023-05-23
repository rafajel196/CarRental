using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Persistance.EF.Configuration
{
    public class CarAddressConfiguration : IEntityTypeConfiguration<CarAddress>
    {
        public void Configure(EntityTypeBuilder<CarAddress> builder)
        {
            builder.HasMany(c => c.Cars)
                .WithOne(c => c.CarAddress)
                .HasForeignKey(c => c.CarAddressId);
        }
    }
}
