using AutoMapper;
using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Functions.Cars.Queries.GetCarDto;
using CarRental.Common.Abstractions.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Queries.GetCarById
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, CarDto>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetCarByIdQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<CarDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetByIdAsync(request.Id);

            if (car is null)
            {
                throw new NotImplementedException();
            }

            var result = _mapper.Map<CarDto>(car);

            return result;
        }
    }
}
