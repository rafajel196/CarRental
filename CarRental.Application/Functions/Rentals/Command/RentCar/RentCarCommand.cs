using MediatR;

namespace CarRental.Application.Functions.Rentals.Command.RentCar
{
    public class RentCarCommand : IRequest<string>
    {
        public int CarId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}