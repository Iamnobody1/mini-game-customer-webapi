using Yoda.Services.Customer.Models;

namespace Yoda.Services.Customer.Services.District;

public interface IDistrictService
{
    IEnumerable<DisWithPosAndSubModel> GetByProvinceId(int id);
    IEnumerable<DistrictModel> GetList(int id);
}
