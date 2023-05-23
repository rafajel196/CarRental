using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Exceptions;
using MediatR;

namespace CarRental.Application.Functions.CarAddresses.Commands.UpdateCarAddress
{
    public class UpdateCarAddressCommandHandler : IRequestHandler<UpdateCarAddressCommand, Unit>
    {
        private readonly ICarAddressRepository _carAddressRepository;

        public UpdateCarAddressCommandHandler(ICarAddressRepository carAddressRepository)
        {
            _carAddressRepository = carAddressRepository;
        }

        public async Task<Unit> Handle(UpdateCarAddressCommand request, CancellationToken cancellationToken)
        {
            var carAddress = await _carAddressRepository.GetByIdAsync(request.Id);
            if (carAddress == null)
            {
                throw new CarAddressNotFoundException();
            }
            carAddress.Street = request.Street;
            carAddress.City = request.City;
            await _carAddressRepository.UpdateAsync(carAddress);

            return Unit.Value;
        }
    }
}
