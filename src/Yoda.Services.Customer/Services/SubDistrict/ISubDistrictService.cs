using Yoda.Services.Customer.Models;

namespace Yoda.Services.Customer.Services.District;

public interface ISubDistrictService
{
    IEnumerable<SubDistrictModel> GetList(int id);
}

