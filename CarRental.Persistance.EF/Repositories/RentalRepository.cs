using CarRental.Application.Contracts.Persistance;
using CarRental.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistance.EF.Repositories
{
    public class RentalRepository : BaseRepository<Rental>, IRentalRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RentalRepository(CarRentalContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetRentIdByCarId(int carId)
        {
            var rentId = _dbContext.Rentals.Any(x => x.CarId == carId).Id;

            return rentId;
        }

        public int GetUserId()
        {
            var userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

            return userId;
        }
    }
}
