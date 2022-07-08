namespace Yoda.Services.Register.Models
{
    public class CustomerModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string Avatar { get; set; }
    }
}
