using CarRental.Application.Functions.Cars.Queries.GetCarDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Queries.GetCarById
{
    public class GetCarByIdQuery : IRequest<CarDto>
    {
        public int Id { get; set; }
    }
}
