using Yoda.Services.Customer.Data;
using Yoda.Services.Customer.Models;

namespace Yoda.Services.Customer.Services.Province;

public class ProvinceService : IProvinceService
{
    private readonly YodaContext _yodaContext;
    public ProvinceService(YodaContext yodaContext)
    {
        _yodaContext = yodaContext;
    }

    public IEnumerable<ProvinceByCountryModel> GetList(int id)
    {
        return _yodaContext.Provinces
        .Where(item => item.EnabledFlag == true && item.Country.Id == id)
        .Select(province => new ProvinceByCountryModel()
        {
            Id = province.Id,
            Name = province.Name
        });
    }
}
