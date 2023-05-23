using MediatR;

namespace CarRental.Application.Functions.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<Unit>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime LicenceDate { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int RoleId { get; set; } = 1;
    }
}