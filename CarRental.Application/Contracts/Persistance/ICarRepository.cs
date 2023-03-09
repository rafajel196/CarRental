using CarRental.Application.Functions.Cars.Queries.GetCarDto;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Contracts.Persistance
{
    public interface ICarRepository : IAsyncRepository<Car>
    {
        Task<List<CarDto>> GetCarsListAsync();
    }
}
