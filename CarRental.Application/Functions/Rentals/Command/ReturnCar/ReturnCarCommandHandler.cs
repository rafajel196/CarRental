﻿using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Exceptions;
using MediatR;

namespace CarRental.Application.Functions.Rentals.Command.ReturnCar
{
    public class ReturnCarCommandHandler : IRequestHandler<ReturnCarCommand, string>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly ICarRepository _carRepository;

        public ReturnCarCommandHandler(IRentalRepository rentalRepository, ICarRepository carRepository)
        {
            _rentalRepository = rentalRepository;
            _carRepository = carRepository;
        }

        public async Task<string> Handle(ReturnCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetByIdAsync(request.CarId);
            if (car == null)
            {
                throw new CarNotFoundException();
            }

            var rentId = _rentalRepository.GetRentIdByCarId(car.Id);

            var rentedCar = await _rentalRepository.GetByIdAsync(rentId);
            if (rentedCar == null)
            {
                throw new CarNotFoundException();
            }

            await _rentalRepository.DeleteAsync(rentedCar);

            car.IsAvailable = true;
            await _carRepository.UpdateAsync(car);

            return $"Car {car.Mark} {car.Model} returned";
        }
    }
}
