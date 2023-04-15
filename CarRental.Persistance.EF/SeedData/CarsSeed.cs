using CarRental.Domain.Entities;
using CarRental.Persistance.EF.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistance.EF.SeedData
{
    public class CarsSeed
    {
        public static List<Car> Get()
        {
            var carAddressId = CarAddressesSeed.Get();

            List<Car> cars = new List<Car>();

            var car1 = new Car()
            {
                Id = 1,
                Mark = "Peugeot",
                Model = "406 Coupe",
                RegNumber = "RLE20095",
                FuelConsumption = 11.5m,
                IsAvailable = true,
                CarAddressId = CarAddressesSeed.Rzeszow,
                PriceCategoryId = 4
            };
            cars.Add(car1);

            var car2 = new Car()
            {
                Id = 2,
                Mark = "BMW",
                Model = "760Li",
                RegNumber = "RZ30571",
                FuelConsumption = 14.2m,
                IsAvailable = true,
                CarAddressId = CarAddressesSeed.Krakow,
                PriceCategoryId = 2
            };
            cars.Add(car2);

            var car3 = new Car()
            {
                Id = 3,
                Mark = "Audi",
                Model = "R8",
                RegNumber = "KR87937",
                FuelConsumption = 12.8m,
                IsAvailable = true,
                CarAddressId = CarAddressesSeed.Wroclaw,
                PriceCategoryId = 3
            };
            cars.Add(car3);

            var car4 = new Car()
            {
                Id = 4,
                Mark = "BMW",
                Model = "E46",
                RegNumber = "RLE30098",
                FuelConsumption = 8.3m,
                IsAvailable = true,
                CarAddressId = CarAddressesSeed.Rzeszow,
                PriceCategoryId = 2
            };
            cars.Add(car4);

            var car5 = new Car()
            {
                Id = 5,
                Mark = "Peugeot",
                Model = "406 Coupe",
                RegNumber = "RLE21372",
                FuelConsumption = 11.5m,
                IsAvailable = true,
                CarAddressId = CarAddressesSeed.Rzeszow,
                PriceCategoryId = 4
            };
            cars.Add(car5);

            var car6 = new Car()
            {
                Id = 6,
                Mark = "Audi",
                Model = "TT",
                RegNumber = "KR91392",
                FuelConsumption = 12.3m,
                IsAvailable = true,
                CarAddressId = CarAddressesSeed.Krakow,
                PriceCategoryId = 1
            };
            cars.Add(car6);

            return cars;
        }
    }
}
