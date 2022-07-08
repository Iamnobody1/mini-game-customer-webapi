using Yoda.Services.Customer.Models;
using Yoda.Services.Customer.Entities;
namespace Yoda.Services.Customer.Services.Country
{
    public interface ICountryService
    {
        IEnumerable<CountryModel> GetList(int id);
    }
}
