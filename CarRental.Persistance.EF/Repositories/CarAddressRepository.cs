using CarRental.Application.Contracts.Persistance;
using CarRental.Domain.Entities;

namespace CarRental.Persistance.EF.Repositories
{
    public class CarAddressRepository : BaseRepository<CarAddress>, ICarAddressRepository
    {
        public CarAddressRepository(CarRentalContext dbContext) : base(dbContext)
        {

        }

        public bool IsAddressExist(string city, string street)
        {
            var isAddressExist = _dbContext.CarAddresses.Any(x => x.City == city && x.Street == street);

            return isAddressExist;
        }

        public bool IsCarAddressExist(int carAddressId)
        {
            var isCarAddressExist = _dbContext.CarAddresses.Any(x => x.Id == carAddressId);

            return isCarAddressExist;
        }

    }
}
