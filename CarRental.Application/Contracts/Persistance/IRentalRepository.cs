using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Contracts.Persistance
{
    public interface IRentalRepository : IAsyncRepository<Rental>
    {
        int GetUserId();
    }
}
