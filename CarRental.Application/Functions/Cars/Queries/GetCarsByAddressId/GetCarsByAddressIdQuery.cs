using CarRental.Application.DTOs;
using MediatR;

namespace CarRental.Application.Functions.Cars.Queries.GetCarsByAddressId
{
    public class GetCarsByAddressIdQuery : IRequest<List<CarDto>>
    {
        public int Id { get; set; }
    }
}
