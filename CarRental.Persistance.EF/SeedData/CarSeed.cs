﻿using CarRental.Domain.Entities;
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
            var carAddressId = CarAddressSeed.Get();

            List<Car> cars = new List<Car>();

            var car1 = new Car()
            {
                Id = 1,
                Mark = "Peugeot",
                Model = "406 Coupe",
                RegNumber = "RLE20095",
                FuelConsumption = 11.5m,
                CarAddressId = CarAddressSeed.Rzeszow
            };

            var car2 = new Car()
            {
                Id = 2,
                Mark = "BMW",
                Model = "760Li",
                RegNumber = "RZ30571",
                FuelConsumption = 14.2m,
                CarAddressId = CarAddressSeed.Krakow
            };

            var car3 = new Car()
            {
                Id = 3,
                Mark = "Audi",
                Model = "R8",
                RegNumber = "KR87937",
                FuelConsumption = 12.8m,
                CarAddressId = CarAddressSeed.Wroclaw
            };

            return cars;
        }
    }
}
