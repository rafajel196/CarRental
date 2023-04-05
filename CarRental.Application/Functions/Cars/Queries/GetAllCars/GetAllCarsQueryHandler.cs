using CarRental.Application.Contracts.Persistance;
using CarRental.Application.DTOs;
using CarRental.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Queries.GetAllCars
{
    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, List<CarDto>>
    {
        private readonly ICarRepository _carRepository;

        public GetAllCarsQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<CarDto>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            var cars = await _carRepository.GetAllAsync();

            if (cars is null)
            {
                throw new CarNotFoundException();
            }

            var sortedCars = cars.OrderBy(x => x.Mark).ThenBy(x => x.Model).ToList();

            var result = new List<CarDto>();
            foreach (var car in sortedCars)
            {
                result.Add(new CarDto()
                {
                    Mark = car.Mark,
                    Model = car.Model
                });
            }

            return result;
        }
    }
}