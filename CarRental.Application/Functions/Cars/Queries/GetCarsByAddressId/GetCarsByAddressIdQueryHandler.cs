using AutoMapper;
using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Functions.Cars.Queries.GetCarDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Queries.GetCarsByAddressId
{
    public class GetCarsByAddressIdQueryHandler : IRequestHandler<GetCarsByAddressIdQuery, List<CarDto>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetCarsByAddressIdQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<List<CarDto>> Handle(GetCarsByAddressIdQuery request, CancellationToken cancellationToken)
        {
            var cars = await _carRepository.GetAllAsync();
            if (cars is null)
            {
                throw new NotImplementedException();
            }

            var carsById = cars.Where(x => x.CarAddressId == request.Id).ToList();
            if (carsById is null)
            {
                throw new NotImplementedException();
            }

            var result = _mapper.Map<List<CarDto>>(carsById);

            return result;
        }
    }
}
