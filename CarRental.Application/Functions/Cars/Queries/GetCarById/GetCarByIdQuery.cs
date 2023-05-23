using CarRental.Application.DTOs;
using MediatR;

namespace CarRental.Application.Functions.Cars.Queries.GetCarById
{
    public class GetCarByIdQuery : IRequest<CarDto>
    {
        public int Id { get; set; }
    }
}
