namespace CarRental.Application.Exceptions
{
    public class CarAddressNotFoundException : NotFoundException
    {
        public CarAddressNotFoundException() : base("Car address not found")
        {
        }
    }
}
