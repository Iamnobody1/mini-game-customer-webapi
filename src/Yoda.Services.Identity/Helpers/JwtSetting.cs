namespace Yoda.Services.Identity.Helpers
{
    public class JwtSetting
    {
        public string Secret { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int TokenValidityInMilliSeconds { get; set; }
    }
}