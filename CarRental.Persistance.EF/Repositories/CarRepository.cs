using AutoMapper;
using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Functions.Cars.Queries.GetCarDto;
using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistance.EF.Repositories
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {

        public CarRepository(CarRentalContext dbContext) : base(dbContext)
        {
        }
    }
}