using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Rentals.Query.Calculator
{
    public class CalculateCostQueryResponse
    {
        public decimal BasePricePerDay { get; set; }
        public decimal TotalDays { get; set; }
        public decimal CarsCountMultipier { get; set; }
        public decimal CarCategoryMultiplier { get; set; }
        public decimal LicenceHavingTimeMultipier { get; set; }
        public decimal FuelPricePerLiter { get; set; }
        public decimal TotalFuelCost { get; set; }
        public decimal TotalBaseCost { get; set; }
        public decimal TotalCostNetto { get; set; }
        public decimal TotalCostBrutto { get; set; }
    }
}
