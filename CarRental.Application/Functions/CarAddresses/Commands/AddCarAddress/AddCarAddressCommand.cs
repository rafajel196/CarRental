using MediatR;

namespace CarRental.Application.Functions.CarAddresses.Commands.AddCarAddress
{
    public class AddCarAddressCommand : IRequest<int>
    {
        public string City { get; set; }
        public string Street { get; set; }
    }
}
