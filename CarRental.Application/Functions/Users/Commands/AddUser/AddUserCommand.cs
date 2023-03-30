using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Users.Commands.AddUser
{
    public class AddUserCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime LicenceDate { get; set; }
    }
}
