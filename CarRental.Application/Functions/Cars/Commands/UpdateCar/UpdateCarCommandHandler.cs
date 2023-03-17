using AutoMapper;
using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Functions.Cars.Queries.GetCarDto;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Commands.UpdateCar
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Unit>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCarCommand updateCar, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetByIdAsync(updateCar.Id);
            if (car is null)
            {
                throw new NotImplementedException();
            }

            car.Mark = updateCar.Mark;
            car.Model = updateCar.Model;
            car.RegNumber = updateCar.RegNumber;
            car.FuelConsumption = updateCar.FuelConsumption;
            car.CarAddressId = updateCar.CarAddressId;

            await _carRepository.UpdateAsync(car);

            return Unit.Value;
        }
    }
}
