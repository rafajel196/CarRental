using MediatR;

namespace CarRental.Application.Functions.Rentals.Command.ReturnCar
{
    public class ReturnCarCommand : IRequest<string>
    {
        public int CarId { get; set; }
    }
}
