using Microsoft.EntityFrameworkCore;
using Yoda.Services.Customer.Data;
using Yoda.Services.Customer.Models;

namespace Yoda.Services.Customer.Services.District;

public class SubDistrictService : ISubDistrictService
{
    private readonly YodaContext _yodaContext;

    public SubDistrictService(YodaContext yodaContext)
    {
        _yodaContext = yodaContext;
    }

    public IEnumerable<SubDistrictModel> GetList(int id)
    {
        return _yodaContext.SubDistricts
        .AsNoTracking()
        .Where(item => item.EnabledFlag == true && item.DistrictId == id)
        .Select(dis => new SubDistrictModel()
        {
            Id = dis.Id,
            Name = dis.Name,
        });
    }
}
