using CarRental.Domain.Entities;

namespace CarRental.Application.Contracts.Persistance
{
    public interface ICarAddressRepository : IAsyncRepository<CarAddress>
    {
        bool IsCarAddressExist(int carAddressId);
        bool IsAddressExist(string city, string street);
    }
}
