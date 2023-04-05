using CarRental.Application.Contracts.Persistance;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Commands.AddCar
{
    public class AddCarCommandHandler : IRequestHandler<AddCarCommand, int>
    {
        private readonly ICarRepository _carRepository;

        public AddCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<int> Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
            var newCar = new Car()
            {
                Mark = request.Mark,
                Model = request.Model,
                RegNumber = request.RegNumber,
                FuelConsumption = request.FuelConsumption,
                CarAddressId = request.CarAddressId
            };

            newCar = await _carRepository.AddAsync(newCar);

            return newCar.Id;
        }
    }
}
