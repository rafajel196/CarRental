using CarRental.Application.Contracts.Persistance;
using CarRental.Application.DTOs;
using CarRental.Application.Exceptions;
using MediatR;

namespace CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressByCarId
{
    public class GetCarAddressByCarIdQueryHandler : IRequestHandler<GetCarAddressByCarIdQuery, CarAddressDto>
    {
        private readonly ICarAddressRepository _carAddressRepository;
        private readonly ICarRepository _carRepository;
        public GetCarAddressByCarIdQueryHandler(ICarAddressRepository carAddressRepository, ICarRepository carRepository)
        {
            _carAddressRepository = carAddressRepository;
            _carRepository = carRepository;
        }

        public async Task<CarAddressDto> Handle(GetCarAddressByCarIdQuery request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetByIdAsync(request.CarId);
            if (car == null)
            {
                throw new CarAddressNotFoundException();
            }
            var address = await _carAddressRepository.GetByIdAsync(car.CarAddressId);
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
