namespace Yoda.Services.Customer.Entities;

public class DistrictEntity
{
    public int Id { get; set; }
    public int ProvinceId { get; set; }
    public string Name { get; set; }
    public bool EnabledFlag { get; set; }

    public IEnumerable<SubDistrictEntity> SubDistricts { get; set; }
    public IEnumerable<PostalCodeEntity> postalCodes { get; set; }
    public ProvinceEntity Province { get; set; }
}
