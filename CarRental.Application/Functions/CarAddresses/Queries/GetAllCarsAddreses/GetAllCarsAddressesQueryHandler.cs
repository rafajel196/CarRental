using AutoMapper;
using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Functions.CarAddresses.Queries.CarAddressModelCommon;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarAddresses.Queries.GetAllCarsAddreses
{
    public class GetAllCarsAddressesQueryHandler : IRequestHandler<GetAllCarsAddresesQuery, List<CarAddressDto>>
    {
        private readonly ICarAddressRepository _carAddressRepository;
        private readonly IMapper _mapper;

        public GetAllCarsAddressesQueryHandler(ICarAddressRepository carAddressRepository, IMapper mapper)
        {
            _carAddressRepository = carAddressRepository;
            _mapper = mapper;
        }

        public async Task<List<CarAddressDto>> Handle(GetAllCarsAddresesQuery request, CancellationToken cancellationToken)
        {
            var carsAddreses = await _carAddressRepository.GetAllAsync();
            if (carsAddreses is null)
            {
                throw new NotImplementedException();
            }
            var carsAddresesDto = _mapper.Map<List<CarAddressDto>>(carsAddreses);

            return carsAddresesDto;
        }
    }
}
