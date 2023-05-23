using CarRental.Application.DTOs;
using MediatR;

namespace CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressById
{
    public class GetCarAddressByIdQuery : IRequest<CarAddressDto>
    {
        public int Id { get; set; }
    }
}
