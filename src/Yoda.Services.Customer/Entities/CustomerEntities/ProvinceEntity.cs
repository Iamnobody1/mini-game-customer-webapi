namespace Yoda.Services.Customer.Entities;

public class ProvinceEntity
{
    public int Id { get; set; }
    public int ProvinceId { get; set; }
    public string Name { get; set; }
    public bool EnabledFlag { get; set; }

    public CountryEntity Country { get; set; }
    public IEnumerable<DistrictEntity> Districts { get; set; }
}
