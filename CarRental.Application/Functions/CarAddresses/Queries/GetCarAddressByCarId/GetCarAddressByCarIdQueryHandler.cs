using AutoMapper;
using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Functions.CarAddresses.Queries.CarAddressModelCommon;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressByCarId
{
    public class GetCarAddressByCarIdQueryHandler : IRequestHandler<GetCarAddressByCarIdQuery, CarAddressDto>
    {
        private readonly ICarAddressRepository _carAddressRepository;
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        public GetCarAddressByCarIdQueryHandler(ICarAddressRepository carAddressRepository, IMapper mapper, ICarRepository carRepository)
        {
            _carAddressRepository = carAddressRepository;
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<CarAddressDto> Handle(GetCarAddressByCarIdQuery request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetByIdAsync(request.CarId);
            if (car == null)
            {
                throw new NotImplementedException();
            }
            var address = await _carAddressRepository.GetByIdAsync(car.CarAddressId);
            var addressDto = _mapper.Map<CarAddressDto>(address);

            return addressDto;
        }
    }
}
