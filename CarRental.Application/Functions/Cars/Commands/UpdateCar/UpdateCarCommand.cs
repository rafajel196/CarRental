using MediatR;

namespace CarRental.Application.Functions.Cars.Commands.UpdateCar
{
    public class UpdateCarCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string RegNumber { get; set; }
        public decimal FuelConsumption { get; set; }
        public bool IsAvailable { get; set; }
        public int CarAddressId { get; set; }
        public int PriceCategoryId { get; set; }
    }
}
