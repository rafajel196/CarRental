using CarRental.Application.Contracts.Persistance;
using CarRental.Domain.Entities;

namespace CarRental.Persistance.EF.Repositories
{
    public class PriceCategoryRepository : BaseRepository<PriceCategory>, IPriceCategoryRepository
    {
        public PriceCategoryRepository(CarRentalContext dbContext) : base(dbContext)
        {
        }

        public bool IsPriceCategoryExist(int priceCategoryId)
        {
            var result = _dbContext.PriceCategories.Any(p => p.Id == priceCategoryId);

            return result;
        }
    }
}
