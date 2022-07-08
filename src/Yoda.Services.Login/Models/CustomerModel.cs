namespace Yoda.Services.Customer.Models
{
    public class CustomerModel
    {
        public guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string Avatar { get; set; }
    }
}
