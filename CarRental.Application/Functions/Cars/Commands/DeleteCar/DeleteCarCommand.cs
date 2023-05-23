using MediatR;

namespace CarRental.Application.Functions.Cars.Commands.DeleteCar
{
    public class DeleteCarCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
