using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Exceptions;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Rentals.Command.RentCar
{
    public class RentCarCommandHandler : IRequestHandler<RentCarCommand, string>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly ICarRepository _carRepository;
        private readonly IUserRepository _userRepository;

        public RentCarCommandHandler(IRentalRepository rentalRepository, ICarRepository carRepository, IUserRepository userRepository)
        {
            _rentalRepository = rentalRepository;
            _carRepository = carRepository;
            _userRepository = userRepository;
        }

        public async Task<string> Handle(RentCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetByIdAsync(request.CarId);
            if (car == null || car.IsAvailable == false)
            {
                throw new CarNotFoundException();
            }

            var rentCar = new Rental()
            {
                CarId = request.CarId,
                UserId = _rentalRepository.GetUserId(),
                RentDate = request.RentDate,
                ReturnDate = request.ReturnDate
            };

            car.IsAvailable = false;
            await _rentalRepository.AddAsync(rentCar);
            await _carRepository.UpdateAsync(car);

            var result = $"Car {car.Mark} {car.Model} rented from {rentCar.RentDate.ToShortDateString()} to {rentCar.ReturnDate.ToShortDateString()}";

            return result;
        }
    }
}
