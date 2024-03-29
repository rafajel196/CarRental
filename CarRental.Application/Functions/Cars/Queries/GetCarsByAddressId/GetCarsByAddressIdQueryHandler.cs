﻿using CarRental.Application.Contracts.Persistance;
using CarRental.Application.DTOs;
using CarRental.Application.Exceptions;
using MediatR;

namespace CarRental.Application.Functions.Cars.Queries.GetCarsByAddressId
{
    public class GetCarsByAddressIdQueryHandler : IRequestHandler<GetCarsByAddressIdQuery, List<CarDto>>
    {
        private readonly ICarRepository _carRepository;

        public GetCarsByAddressIdQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<CarDto>> Handle(GetCarsByAddressIdQuery request, CancellationToken cancellationToken)
        {
            var cars = await _carRepository.GetAllAsync();
            if (cars is null)
            {
                throw new CarNotFoundException();
            }

            var carsById = cars.Where(x => x.CarAddressId == request.Id).ToList();
            if (carsById.Count == 0)
            {
                throw new CarNotFoundException();
            }
            var sortedCarsById = carsById.OrderBy(x => x.Mark).ThenBy(x => x.Model).ToList();

            var result = new List<CarDto>();
            foreach (var car in sortedCarsById)
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
