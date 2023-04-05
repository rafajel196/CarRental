using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Rentals.Command.ReturnCar
{
    public class ReturnCarCommand : IRequest<string>
    {
        public int CarId { get; set; }
    }
}
