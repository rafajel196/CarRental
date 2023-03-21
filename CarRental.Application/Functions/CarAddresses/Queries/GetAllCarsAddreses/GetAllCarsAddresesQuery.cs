using CarRental.Application.Functions.CarAddresses.Queries.CarAddressModelCommon;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarAddresses.Queries.GetAllCarsAddreses
{
    public class GetAllCarsAddresesQuery : IRequest<List<CarAddressDto>>
    {
    }
}
