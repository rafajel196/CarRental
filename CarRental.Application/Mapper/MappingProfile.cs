using AutoMapper;
using CarRental.Application.Functions.CarAddresses.Commands.AddCarAddress;
using CarRental.Application.Functions.CarAddresses.Queries.CarAddressModelCommon;
using CarRental.Application.Functions.Cars.Commands.AddCar;
using CarRental.Application.Functions.Cars.Queries.GetCarDto;
using CarRental.Application.Functions.Users.Queries.GetUserModelsCommon;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<AddCarCommand, Car>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CarAddress, CarAddressDto>().ReverseMap();
            CreateMap<AddCarAddressCommand, CarAddress>().ReverseMap();
        }
    }
}
