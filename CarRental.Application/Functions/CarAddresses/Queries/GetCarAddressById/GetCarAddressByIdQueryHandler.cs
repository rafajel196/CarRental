using AutoMapper;
using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Exceptions;
using CarRental.Application.Functions.CarAddresses.Queries.CarAddressModelCommon;
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
        private readonly IMapper _mapper;
        public GetCarAddressByIdQueryHandler(ICarAddressRepository carAddressRepository, IMapper mapper)
        {
            _carAddressRepository = carAddressRepository;
            _mapper = mapper;
        }

        public async Task<CarAddressDto> Handle(GetCarAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var address = await _carAddressRepository.GetByIdAsync(request.Id);
            if (address == null)
            {
                throw new CarAddressNotFoundException();
            }
            var addressDto = _mapper.Map<CarAddressDto>(address);
            return addressDto;
        }
    }
}
