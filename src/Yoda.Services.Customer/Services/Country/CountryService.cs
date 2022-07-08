using Yoda.Services.Customer.Data;
using Yoda.Services.Customer.Models;

namespace Yoda.Services.Customer.Services.Country
{
    public class CountryService : ICountryService
    {
        private readonly YodaContext _yodaContext;
        public CountryService(YodaContext yodaContext)
        {
            _yodaContext = yodaContext;
        }

        public IEnumerable<CountryModel> GetList(int id)
        {
            return _yodaContext.Countries
            .Select(country => new CountryModel()
            {
                Id = country.Id,
                Name = country.Name
            });
        }
    }
}

