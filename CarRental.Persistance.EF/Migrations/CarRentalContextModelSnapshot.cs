﻿// <auto-generated />
using System;
using CarRental.Persistance.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRental.Persistance.EF.Migrations
{
    [DbContext(typeof(CarRentalContext))]
    partial class CarRentalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarRental.Domain.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarAddressId")
                        .HasColumnType("int");

                    b.Property<decimal>("FuelConsumption")
                        .HasPrecision(3, 1)
                        .HasColumnType("decimal(3,1)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Mark")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriceCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("RegNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarAddressId");

                    b.HasIndex("PriceCategoryId");

                    b.ToTable("Cars", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarAddressId = 1,
                            FuelConsumption = 11.5m,
                            IsAvailable = true,
                            Mark = "Peugeot",
                            Model = "406 Coupe",
                            PriceCategoryId = 4,
                            RegNumber = "RLE20095"
                        },
                        new
                        {
                            Id = 2,
                            CarAddressId = 2,
                            FuelConsumption = 14.2m,
                            IsAvailable = true,
                            Mark = "BMW",
                            Model = "760Li",
                            PriceCategoryId = 2,
                            RegNumber = "RZ30571"
                        },
                        new
                        {
                            Id = 3,
                            CarAddressId = 3,
                            FuelConsumption = 12.8m,
                            IsAvailable = true,
                            Mark = "Audi",
                            Model = "R8",
                            PriceCategoryId = 3,
                            RegNumber = "KR87937"
                        },
                        new
                        {
                            Id = 4,
                            CarAddressId = 1,
                            FuelConsumption = 8.3m,
                            IsAvailable = true,
                            Mark = "BMW",
                            Model = "E46",
                            PriceCategoryId = 2,
                            RegNumber = "RLE30098"
                        },
                        new
                        {
                            Id = 5,
                            CarAddressId = 1,
                            FuelConsumption = 11.5m,
                            IsAvailable = true,
                            Mark = "Peugeot",
                            Model = "406 Coupe",
                            PriceCategoryId = 4,
                            RegNumber = "RLE21372"
                        },
                        new
                        {
                            Id = 6,
                            CarAddressId = 2,
                            FuelConsumption = 12.3m,
                            IsAvailable = true,
                            Mark = "Audi",
                            Model = "TT",
                            PriceCategoryId = 1,
                            RegNumber = "KR91392"
                        });
                });

            modelBuilder.Entity("CarRental.Domain.Entities.CarAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarAddresses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Rzeszów",
                            Street = "Architektów 4"
                        },
                        new
                        {
                            Id = 2,
                            City = "Kraków",
                            Street = "Rostafińskiego 9"
                        },
                        new
                        {
                            Id = 3,
                            City = "Wrocław",
                            Street = "Witelona 25"
                        });
                });

            modelBuilder.Entity("CarRental.Domain.Entities.PriceCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Multiplier")
                        .HasPrecision(2, 1)
                        .HasColumnType("decimal(2,1)");

                    b.HasKey("Id");

                    b.ToTable("PriceCategories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Basic",
                            Multiplier = 1m
                        },
                        new
                        {
                            Id = 2,
                            Category = "Standard",
                            Multiplier = 1.3m
                        },
                        new
                        {
                            Id = 3,
                            Category = "Medium",
                            Multiplier = 1.6m
                        },
                        new
                        {
                            Id = 4,
                            Category = "Premium",
                            Multiplier = 2m
                        });
                });

            modelBuilder.Entity("CarRental.Domain.Entities.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("date");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rentals", (string)null);
                });

            modelBuilder.Entity("CarRental.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "User"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Manager"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("CarRental.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LicenceDate")
                        .HasColumnType("date");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("CarRental.Domain.Entities.Car", b =>
                {
                    b.HasOne("CarRental.Domain.Entities.CarAddress", "CarAddress")
                        .WithMany("Cars")
                        .HasForeignKey("CarAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRental.Domain.Entities.PriceCategory", "PriceCategory")
                        .WithMany("Cars")
                        .HasForeignKey("PriceCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarAddress");

                    b.Navigation("PriceCategory");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.User", b =>
                {
                    b.HasOne("CarRental.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.CarAddress", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.PriceCategory", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
