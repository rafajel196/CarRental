using CarRental.Application.Contracts.Persistance;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistance.EF.Repositories
{
    public class CarAddressRepository : BaseRepository<CarAddress>, ICarAddressRepository
    {
        public CarAddressRepository(CarRentalContext dbContext) : base(dbContext)
        {

        }
    }
}
