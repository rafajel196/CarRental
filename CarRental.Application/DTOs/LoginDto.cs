namespace CarRental.Application.DTOs
{
    public record LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
