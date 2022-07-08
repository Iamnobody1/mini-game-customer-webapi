using Microsoft.EntityFrameworkCore;
using Yoda.Services.Customer.Data;
using Yoda.Services.Customer.Models;

namespace Yoda.Services.Customer.Services.PostalCode
{
    public class PostalCodeService : IPostalCodeService
    {
        private readonly YodaContext _yodaContext;

        public PostalCodeService(YodaContext yodaContext)
        {
            _yodaContext = yodaContext;
        }
        public IEnumerable<PostalCodeModel> GetList(int id)
        {
            return _yodaContext
            .PostalCodes
            .AsNoTracking()
            .Where(pos => pos.DistrictId == id && pos.EnabledFlag == true)
            .Select(postal => new PostalCodeModel()
            {
                Id = postal.Id,
                PostCode = postal.PostCode
            });
        }
    }
}
