using AutoMapper;
using CarRental.Application.Contracts.Persistance;
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
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;

        public GetAllCarsQueryHandler(IMapper mapper, ICarRepository carRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }

        public async Task<List<CarDto>> Handle(GetAllCarsQuery query, CancellationToken cancellationToken)
        {
            var result = await _carRepository.GetCarsListAsync();

            return result;
        }
    }
}
