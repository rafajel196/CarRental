using AutoMapper;
using CarRental.Application.Contracts.Persistance;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Commands.AddCar
{
    public class AddCarCommandHandler : IRequestHandler<AddCarCommand, Unit>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public AddCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
            var newCar = _mapper.Map<Car>(request);

            newCar = await _carRepository.AddAsync(newCar);

            return Unit.Value;
        }
    }
}
