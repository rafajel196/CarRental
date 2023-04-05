using CarRental.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressByCarId
{
    public class GetCarAddressByCarIdQuery : IRequest<CarAddressDto>
    {
        public int CarId { get; set; }
    }
}
