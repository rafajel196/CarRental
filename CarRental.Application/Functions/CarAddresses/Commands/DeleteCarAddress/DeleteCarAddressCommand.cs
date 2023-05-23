using MediatR;

namespace CarRental.Application.Functions.CarAddresses.Commands.DeleteCarAddress
{
    public class DeleteCarAddressCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
