using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistance.EF.SeedData
{
    public class RoleSeed
    {
        public static List<Role> Get()
        {
            List<Role> roles = new List<Role>()
            {
                new Role()
                {
                    Id = 1,
                    Name = "User"
                },

                new Role()
                {
                    Id = 2,
                    Name = "Manager"
                },

                new Role()
                {
                    Id = 3,
                    Name = "Admin"
                }
            };

            return roles;
        }
    }
}
