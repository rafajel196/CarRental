namespace CarRental.Application.Authentication
{
    public class AuthenticationSettings
    {
        public string JwtKey { get; set; }
        public int JwtExpireDayd { get; set; }
        public string JwtIssuer { get; set; }
    }
}
