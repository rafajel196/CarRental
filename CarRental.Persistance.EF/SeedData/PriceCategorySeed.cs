using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistance.EF.SeedData
{
    public class PriceCategorySeed
    {
        public static List<PriceCategory> Get()
        {
            List<PriceCategory> priceCategories = new List<PriceCategory>()
            {
                new PriceCategory()
                {
                    Id = 1,
                    Category = "Basic",
                    Multiplier = 1m
                },
                
                new PriceCategory()
                {
                    Id = 2,
                    Category = "Standard",
                    Multiplier = 1.3m
                },

                new PriceCategory()
                {
                    Id = 3,
                    Category = "Medium",
                    Multiplier = 1.6m
                },

                new PriceCategory()
                {
                    Id = 4,
                    Category = "Premium",
                    Multiplier = 2m
                }
            };

            return priceCategories;
        }
    }
}
