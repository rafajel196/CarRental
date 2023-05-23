namespace CarRental.Application.Exceptions
{
    public class CannotRentThePremiumCarException : Exception
    {
        public CannotRentThePremiumCarException() : base("Cannot rent the premium cars with a driving licence less than 3 years old")
        {
        }
    }
}
