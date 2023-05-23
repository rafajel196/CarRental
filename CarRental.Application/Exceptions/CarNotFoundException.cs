namespace CarRental.Application.Exceptions
{
    public class CarNotFoundException : NotFoundException
    {
        public CarNotFoundException() : base("Car not found")
        {
        }
    }
}
