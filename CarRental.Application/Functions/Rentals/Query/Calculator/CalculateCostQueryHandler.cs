using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Exceptions;
using MediatR;

namespace CarRental.Application.Functions.Rentals.Query.Calculator
{
    public class CalculateCostQueryHandler : IRequestHandler<CalculateCostQuery, CalculateCostQueryResponse>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly ICarRepository _carRepository;
        private readonly IUserRepository _userRepository;

        private decimal numbersOfCarsMultipier = 1m;
        private decimal licenceHavingTimeMultiplier = 1m;
        private decimal fuelPricePerLiter = 6.57m;
        private decimal basePricePerDay = 300m;

        public CalculateCostQueryHandler(IRentalRepository rentalRepository, ICarRepository carRepository, IUserRepository userRepository)
        {
            _rentalRepository = rentalRepository;
            _carRepository = carRepository;
            _userRepository = userRepository;
        }

        public async Task<CalculateCostQueryResponse> Handle(CalculateCostQuery request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetByIdAsync(request.CarId);
            if (car == null)
            {
                throw new CarNotFoundException();
            }

            var numbersOfCars = (await _carRepository.GetAllSelectedCars(car.Mark, car.Model)).Count();
            if (numbersOfCars < 3)
            {
                numbersOfCarsMultipier = 1.15m;
            }

            var carCategoryMultiplier = _rentalRepository.GetCarCategoryMultiplier(car.PriceCategoryId);

            var user = await _userRepository.GetByIdAsync(_rentalRepository.GetUserId());

            var licenceHavingTime = DateTime.Now - user.LicenceDate;
            if (licenceHavingTime.TotalDays < 365 * 5)
            {
                licenceHavingTimeMultiplier = 1.2m;
            }
            if (licenceHavingTime.TotalDays < 365 * 3 && car.PriceCategoryId == 4)
            {
                throw new CannotRentThePremiumCarException();
            }

            var rentDays = (decimal)(request.ReturnDate - request.RentDate).Days;
            var basePrice = basePricePerDay * rentDays * carCategoryMultiplier;
            var basePriceWithCarsMultiplier = basePrice * numbersOfCarsMultipier;
            var basePriceWithLicenceMultiplier = basePrice * licenceHavingTimeMultiplier;

            var totalBasePrice = basePriceWithCarsMultiplier + (basePriceWithLicenceMultiplier - basePrice);
            var totalFuelPrice = fuelPricePerLiter * car.FuelConsumption * (request.EstimatedKilometers) / 100;

            var totalCostNetto = totalBasePrice + totalFuelPrice;
            var totalCostBrutto = totalCostNetto * 1.23m;

            var result = new CalculateCostQueryResponse()
            {
                BasePricePerDay = basePricePerDay,
                TotalDays = rentDays,
                CarsCountMultipier = numbersOfCarsMultipier,
                CarCategoryMultiplier = carCategoryMultiplier,
                LicenceHavingTimeMultipier = licenceHavingTimeMultiplier,
                FuelPricePerLiter = fuelPricePerLiter,
                TotalFuelCost = totalFuelPrice,
                TotalBaseCost = totalBasePrice,
                TotalCostNetto = totalCostNetto,
                TotalCostBrutto = totalCostBrutto
            };

            return result;
        }
    }
}
