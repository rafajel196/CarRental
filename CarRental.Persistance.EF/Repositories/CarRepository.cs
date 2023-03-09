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

        public async Task<List<CarDto>> GetCarsListAsync()
        {
            var cars = await _dbContext.Cars.GroupBy(x => new { x.Mark, x.Model }).Select(x => new CarDto { Mark = x.Key.Mark, Model = x.Key.Model }).ToListAsync();

            return cars;
        }
    }
}