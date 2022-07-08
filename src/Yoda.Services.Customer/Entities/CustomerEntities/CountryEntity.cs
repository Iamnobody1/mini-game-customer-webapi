namespace Yoda.Services.Customer.Entities;

public class CountryEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool EnabledFlag { get; set; }

    public IEnumerable<ProvinceEntity> Provinces { get; set; }
}
