namespace CarRental.Application.Exceptions
{
    public class InvalidEmailOrPasswordException : BadRequestException
    {
        public InvalidEmailOrPasswordException() : base("Invalid email or password")
        {
        }
    }
}
