using CarRental.Application.Contracts.Persistance;
using CarRental.Application.DTOs;
using CarRental.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressById
{
    public class GetCarAddressByIdQueryHandler : IRequestHandler<GetCarAddressByIdQuery, CarAddressDto>
    {
        private readonly ICarAddressRepository _carAddressRepository;
        public GetCarAddressByIdQueryHandler(ICarAddressRepository carAddressRepository)
        {
            _carAddressRepository = carAddressRepository;
        }

        public async Task<CarAddressDto> Handle(GetCarAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var address = await _carAddressRepository.GetByIdAsync(request.Id);
            if (address == null)
            {
                throw new CarAddressNotFoundException();
            }

            var addressDto = new CarAddressDto()
            {
                City = address.City,
                Street = address.Street
            };

            return addressDto;
        }
    }
}
