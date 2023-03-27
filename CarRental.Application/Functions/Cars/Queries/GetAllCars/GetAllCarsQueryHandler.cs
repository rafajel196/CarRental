using AutoMapper;
using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Exceptions;
using CarRental.Application.Functions.Cars.Queries.GetCarDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Queries.GetAllCars
{
    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, List<CarDto>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetAllCarsQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<List<CarDto>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            var cars = await _carRepository.GetAllAsync();

            if (cars is null)
            {
                throw new CarNotFoundException();
            }

            var result = _mapper.Map<List<CarDto>>(cars);

            return result;
        }
    }
}