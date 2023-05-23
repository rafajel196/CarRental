using CarRental.Domain.Entities;

namespace CarRental.Application.Contracts.Persistance
{
    public interface ICarRepository : IAsyncRepository<Car>
    {
        Task<List<Car>> GetAllSelectedCars(string mark, string model);
    }
}
