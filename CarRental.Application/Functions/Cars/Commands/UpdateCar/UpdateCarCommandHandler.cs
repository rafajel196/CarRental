using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Exceptions;
using MediatR;

namespace CarRental.Application.Functions.Cars.Commands.UpdateCar
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Unit>
    {
        private readonly ICarRepository _carRepository;

        public UpdateCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Unit> Handle(UpdateCarCommand updateCar, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetByIdAsync(updateCar.Id);
            if (car is null)
            {
                throw new CarNotFoundException();
            }

            car.Mark = updateCar.Mark;
            car.Model = updateCar.Model;
            car.RegNumber = updateCar.RegNumber;
            car.FuelConsumption = updateCar.FuelConsumption;
            car.IsAvailable = updateCar.IsAvailable;
            car.CarAddressId = updateCar.CarAddressId;
            car.PriceCategoryId = updateCar.PriceCategoryId;

            await _carRepository.UpdateAsync(car);

            return Unit.Value;
        }
    }
}
