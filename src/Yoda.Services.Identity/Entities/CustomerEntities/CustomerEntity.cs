namespace Yoda.Services.Identity.Entities
{
    public class CustomerEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string Avatar { get; set; }

        public IEnumerable<RefreshTokenEntity> RefreshTokens { get; set; }
    }
}
