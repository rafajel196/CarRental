using CarRental.Domain.Entities;

namespace CarRental.Application.Contracts.Persistance
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        bool IsEmailExist(string email);
        Task<User> GetUserByEmail(string email);
    }
}
