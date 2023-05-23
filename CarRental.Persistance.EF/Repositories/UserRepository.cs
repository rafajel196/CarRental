using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Exceptions;
using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Persistance.EF.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(CarRentalContext dbContext) : base(dbContext)
        {

        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
            {
                throw new InvalidEmailOrPasswordException();
            }

            return user;
        }

        public bool IsEmailExist(string email)
        {
            var isEmailAllreadyInUse = _dbContext.Users.Any(x => x.Email == email);

            return isEmailAllreadyInUse;
        }
    }
}
