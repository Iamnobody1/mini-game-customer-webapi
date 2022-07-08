using Yoda.Services.Customer.Models;

namespace Yoda.Services.Customer.Services.Province
{
    public interface IProvinceService
    {
        IEnumerable<ProvinceByCountryModel> GetList(int id);
    }
}
