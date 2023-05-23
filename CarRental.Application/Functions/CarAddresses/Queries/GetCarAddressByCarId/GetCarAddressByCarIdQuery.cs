using CarRental.Application.DTOs;
using MediatR;

namespace CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressByCarId
{
    public class GetCarAddressByCarIdQuery : IRequest<CarAddressDto>
    {
        public int CarId { get; set; }
    }
}
