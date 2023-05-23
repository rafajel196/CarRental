namespace CarRental.Application.Exceptions
{
    public class CarAddressNotFoundException : Exception
    {
        public CarAddressNotFoundException() : base("Car address not found")
        {
        }
    }
}
