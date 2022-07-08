namespace Yoda.Services.Customer.Models;

public class DisWithPosAndSubModel : DistrictModel
{
    public IEnumerable<SubDistrictModel> SubDistricts { get; set; }
    public IEnumerable<PostalCodeModel> PostalCodes { get; set; }
}
