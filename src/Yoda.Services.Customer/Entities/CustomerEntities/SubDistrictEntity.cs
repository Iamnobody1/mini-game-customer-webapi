namespace Yoda.Services.Customer.Entities;

public class SubDistrictEntity
{
    public int Id { get; set; }
    public int DistrictId { get; set; }
    public string Name { get; set; }
    public bool EnabledFlag { get; set; }

    public DistrictEntity District { get; set; }
    public IEnumerable<AddressEntity> Addresses { get; set; }
}
