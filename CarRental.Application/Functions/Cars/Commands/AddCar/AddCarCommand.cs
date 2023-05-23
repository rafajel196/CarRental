using MediatR;

namespace CarRental.Application.Functions.Cars.Commands.AddCar
{
    public class AddCarCommand : IRequest<int>
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public string RegNumber { get; set; }
        public decimal FuelConsumption { get; set; }
        public bool IsAvailable { get; set; } = true;

        public int CarAddressId { get; set; }
        public int PriceCategoryId { get; set; }
    }

}
