using CarRental.Domain.Entities;

namespace CarRental.Application.Contracts.Persistance
{
    public interface IPriceCategoryRepository : IAsyncRepository<PriceCategory>
    {
        bool IsPriceCategoryExist(int priceCategoryId);
    }
}
