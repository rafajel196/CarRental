namespace CarRental.Application.Exceptions
{
    public class CarNotFoundException : Exception
    {
        public CarNotFoundException() : base("Car not found")
        {
        }
    }
}
