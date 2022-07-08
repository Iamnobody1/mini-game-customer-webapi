using Yoda.Services.Customer.Models;

namespace Yoda.Services.Customer.Services.PostalCode
{
    public interface IPostalCodeService
    {
        IEnumerable<PostalCodeModel> GetList(int id);
    }
}
