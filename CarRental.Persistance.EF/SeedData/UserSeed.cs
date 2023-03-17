using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistance.EF.SeedData
{
    public class UserSeed
    {
        public static List<User> Get()
        {
            List<User> users = new List<User>();

            var user1 = new User()
            {
                Id = 1,
                FullName = "Rafał Krupa",
                Email = "rafajel196@gmail.com",
                BirthDate = new DateTime(1998, 6, 19),
                LicenceDate = new DateTime(2016, 6, 20)
            };
            users.Add(user1);

            var user2 = new User()
            {
                Id = 2,
                FullName = "Janusz Placek",
                Email = "jplacek@wp.pl",
                BirthDate = new DateTime(2005, 9, 4),
                LicenceDate = new DateTime(2022, 1, 24)
            };
            users.Add(user2);

            var user3 = new User()
            {
                Id = 3,
                FullName = "Adam Małysz",
                Email = "adaśleć@gmail.com",
                BirthDate = new DateTime(1977, 12, 3),
                LicenceDate = new DateTime(1996, 1, 11)
            };
            users.Add(user3);

            return users;
        }
    }
}
