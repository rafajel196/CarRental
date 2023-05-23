using CarRental.Application.Contracts.Persistance;
using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Persistance.EF.Repositories
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {

        public CarRepository(CarRentalContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Car>> GetAllSelectedCars(string mark, string model)
        {
            var cars = await _dbContext.Cars.Where(m => m.Mark == mark && m.Model == model).ToListAsync();

            return cars;
        }
    }
}