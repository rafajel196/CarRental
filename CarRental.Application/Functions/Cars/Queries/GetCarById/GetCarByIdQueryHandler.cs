﻿using CarRental.Application.Contracts.Persistance;
using CarRental.Application.DTOs;
using CarRental.Application.Exceptions;
using MediatR;

namespace CarRental.Application.Functions.Cars.Queries.GetCarById
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, CarDto>
    {
        private readonly ICarRepository _carRepository;

        public GetCarByIdQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<CarDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetByIdAsync(request.Id);

            if (car is null)
            {
                throw new CarNotFoundException();
            }

            var result = new CarDto()
            {
                Mark = car.Mark,
                Model = car.Model
            };

            return result;
        }
    }
}
