﻿using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Persistance.EF.Configuration
{
    public class PriceCategoryConfiguration : IEntityTypeConfiguration<PriceCategory>
    {
        public void Configure(EntityTypeBuilder<PriceCategory> builder)
        {
            builder.Property(p => p.Category).IsRequired();
            builder.Property(p => p.Multiplier)
                .IsRequired()
                .HasPrecision(2, 1);

            builder.HasMany(p => p.Cars)
                .WithOne(p => p.PriceCategory)
                .HasForeignKey(p => p.PriceCategoryId);
        }
    }
}
