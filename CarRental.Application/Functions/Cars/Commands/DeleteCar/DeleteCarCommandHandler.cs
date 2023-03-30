using AutoMapper;
using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Commands.DeleteCar
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, int>
    {
        private readonly ICarRepository _carRepository;

        public DeleteCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<int> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetByIdAsync(request.Id);
            if (car is null)
            {
                throw new CarNotFoundException();
            }
            await _carRepository.DeleteAsync(car);

            return car.Id;
        }
    }
}
