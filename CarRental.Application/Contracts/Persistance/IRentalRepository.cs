using CarRental.Domain.Entities;

namespace CarRental.Application.Contracts.Persistance
{
    public interface IRentalRepository : IAsyncRepository<Rental>
    {
        int GetUserId();
        int GetRentIdByCarId(int carId);
        decimal GetCarCategoryMultiplier(int categoryId);
    }
}
