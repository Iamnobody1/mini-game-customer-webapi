namespace Yoda.Services.Customer.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int SubDistrictId { get; set; }
        public string Address { get; set; }
        public bool EnabledFlag { get; set; } = true;
        public int PostalCodeId { get; set; }
    }
}
