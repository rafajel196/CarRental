using CarRental.Application.Contracts.Persistance;
using CarRental.Domain.Entities;
using MediatR;

namespace CarRental.Application.Functions.CarAddresses.Commands.AddCarAddress
{
    public class AddCarAddressCommandHandler : IRequestHandler<AddCarAddressCommand, int>
    {
        private readonly ICarAddressRepository _carAddressRepository;
        public AddCarAddressCommandHandler(ICarAddressRepository carAddressRepository)
        {
            _carAddressRepository = carAddressRepository;
        }

        public async Task<int> Handle(AddCarAddressCommand request, CancellationToken cancellationToken)
        {
            var addCar = new CarAddress()
            {
                City = request.City,
                Street = request.Street
            };

            var result = await _carAddressRepository.AddAsync(addCar);

            return result.Id;
        }
    }
}
