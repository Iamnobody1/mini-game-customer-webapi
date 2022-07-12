namespace Yoda.Services.Login.Models
{
    public class JwtTokenModel
    {
        public string Token { get; set; }
        public DateTime Expire { get; set; }
    }
}
