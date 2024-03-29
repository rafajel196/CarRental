﻿using CarRental.Application.Contracts.Persistance;
using CarRental.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CarRental.Persistance.EF.Repositories
{
    public class RentalRepository : BaseRepository<Rental>, IRentalRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RentalRepository(CarRentalContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public decimal GetCarCategoryMultiplier(int categoryId)
        {
            var categoryMultiplier = (decimal)(_dbContext.PriceCategories.FirstOrDefault(x => x.Id == categoryId).Multiplier);

            return categoryMultiplier;
        }

        public int GetRentIdByCarId(int carId)
        {
            var rentId = _dbContext.Rentals.FirstOrDefault(x => x.CarId == carId).Id;

            return rentId;
        }

        public int GetUserId()
        {
            var userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

            return userId;
        }
    }
}
