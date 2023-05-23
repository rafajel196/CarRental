using CarRental.Application.DTOs;
using MediatR;

namespace CarRental.Application.Functions.CarAddresses.Queries.GetAllCarsAddreses
{
    public class GetAllCarsAddressesQuery : IRequest<List<CarAddressDto>>
    {
    }
}
