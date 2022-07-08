using Microsoft.EntityFrameworkCore;

namespace Yoda.Services.Customer.Entities;

public class AddressEntity
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int SubDistrictId { get; set; }
    public string Address { get; set; }
    public bool EnabledFlag { get; set; }
    public int PostalCodeId { get; set; }

    public CustomerEntity Customer { get; set; }
    public SubDistrictEntity SubDistrict { get; set; }
}
