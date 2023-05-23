using CarRental.Application.DTOs;
using MediatR;

namespace CarRental.Application.Functions.Cars.Queries.GetAllCars
{
    public class GetAllCarsQuery : IRequest<List<CarDto>>
    {
    }
}
