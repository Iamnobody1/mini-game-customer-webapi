namespace Yoda.Services.Login.Models
{
    public class YodaToken
    {
        public string Token { get; set; }
        public DateTime Expire { get; set; }
    }
}
