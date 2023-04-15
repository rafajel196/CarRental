using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Rentals.Query.Calculator
{
    public class CalculateCostQuery : IRequest<CalculateCostQueryResponse>
    {
        public int CarId { get; set; }
        public int EstimatedKilometers { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
