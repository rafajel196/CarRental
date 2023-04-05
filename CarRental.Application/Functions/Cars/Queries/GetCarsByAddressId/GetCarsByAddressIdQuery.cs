using CarRental.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Queries.GetCarsByAddressId
{
    public class GetCarsByAddressIdQuery : IRequest<List<CarDto>>
    {
        public int Id { get; set; }
    }
}
