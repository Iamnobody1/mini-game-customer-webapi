namespace Yoda.Services.Customer.Entities;

public class PostalCodeEntity
{
    public int Id { get; set; }
    public int DistrictId { get; set; }
    public int PostCode { get; set; }
    public bool EnabledFlag { get; set; }

    public DistrictEntity District { get; set; }
}

