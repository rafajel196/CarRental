using CarRental.Application.Contracts.Persistance;
using CarRental.Application.DTOs;
using CarRental.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarAddresses.Queries.GetAllCarsAddreses
{
    public class GetAllCarsAddressesQueryHandler : IRequestHandler<GetAllCarsAddressesQuery, List<CarAddressDto>>
    {
        private readonly ICarAddressRepository _carAddressRepository;

        public GetAllCarsAddressesQueryHandler(ICarAddressRepository carAddressRepository)
        {
            _carAddressRepository = carAddressRepository;
        }

        public async Task<List<CarAddressDto>> Handle(GetAllCarsAddressesQuery request, CancellationToken cancellationToken)
        {
            var carsAddreses = await _carAddressRepository.GetAllAsync();
            if (carsAddreses is null)
            {
                throw new CarAddressNotFoundException();
            }
            var sortedCarsAddresses = carsAddreses.OrderBy(x => x.City).ThenBy(x => x.Street).ToList();

            var carsAddresesDto = new List<CarAddressDto>();
            foreach (var car in sortedCarsAddresses)
            {
                carsAddresesDto.Add(new CarAddressDto()
                {
                    City = car.City,
                    Street = car.Street
                });
            }

            return carsAddresesDto;
        }
    }
}
