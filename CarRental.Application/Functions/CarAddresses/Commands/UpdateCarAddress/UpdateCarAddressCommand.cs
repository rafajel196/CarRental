using MediatR;

namespace CarRental.Application.Functions.CarAddresses.Commands.UpdateCarAddress
{
    public class UpdateCarAddressCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
