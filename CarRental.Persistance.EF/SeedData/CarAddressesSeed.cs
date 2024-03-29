﻿using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistance.EF.SeedData
{
    public class CarAddressesSeed
    {
        public static int Rzeszow = 1;
        public static int Krakow = 2;
        public static int Wroclaw = 3;

        public static List<CarAddress> Get()
        {
            List<CarAddress> carAddresses = new List<CarAddress>();

            var address1 = new CarAddress()
            {
                Id = 1,
                City = "Rzeszów",
                Street = "Architektów 4"
            };
            carAddresses.Add(address1);

            var address2 = new CarAddress()
            {
                Id = 2,
                City = "Kraków",
                Street = "Rostafińskiego 9"
            };
            carAddresses.Add(address2);

            var address3 = new CarAddress()
            {
                Id = 3,
                City = "Wrocław",
                Street = "Witelona 25"
            };
            carAddresses.Add(address3);

            return carAddresses;
        }
    }
}
