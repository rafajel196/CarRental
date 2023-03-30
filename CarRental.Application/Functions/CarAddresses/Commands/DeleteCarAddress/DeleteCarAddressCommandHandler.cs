using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarAddresses.Commands.DeleteCarAddress
{
    public class DeleteCarAddressCommandHandler : IRequestHandler<DeleteCarAddressCommand, Unit>
    {
        private readonly ICarAddressRepository _carAddressRepository;

        public DeleteCarAddressCommandHandler(ICarAddressRepository carAddressRepository)
        {
            _carAddressRepository = carAddressRepository;
        }

        public async Task<Unit> Handle(DeleteCarAddressCommand request, CancellationToken cancellationToken)
        {
            var carAddress = await _carAddressRepository.GetByIdAsync(request.Id);
            if (carAddress == null)
            {
                throw new CarAddressNotFoundException();
            }
            await _carAddressRepository.DeleteAsync(carAddress);

            return Unit.Value;
        }
    }
}
