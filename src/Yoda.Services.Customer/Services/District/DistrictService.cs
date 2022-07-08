using Microsoft.EntityFrameworkCore;
using Yoda.Services.Customer.Data;
using Yoda.Services.Customer.Models;

namespace Yoda.Services.Customer.Services.District;

public class DistrictService : IDistrictService
{
    private readonly YodaContext _yodaContext;

    public DistrictService(YodaContext yodaContext)
    {
        _yodaContext = yodaContext;
    }

    public IEnumerable<DistrictModel> GetList(int id)
    {
        return _yodaContext.Districts
        .AsNoTracking()
        .Where(item => item.ProvinceId == id)
        .Select(dis => new DistrictModel()
        {
            Id = dis.Id,
            Name = dis.Name,
        });
    }

    public IEnumerable<DisWithPosAndSubModel> GetByProvinceId(int id)
    {
        var items = _yodaContext.Districts
        .Where(item => item.EnabledFlag == true && item.ProvinceId == id)
        .Select(dis => new DisWithPosAndSubModel()
        {
            Id = dis.Id,
            Name = dis.Name,
            SubDistricts = dis.SubDistricts
            .Select(sub => new SubDistrictModel()
            {
                Id = sub.Id,
                Name = sub.Name
            }
            ),
            PostalCodes = dis.postalCodes
            .Select(pos => new PostalCodeModel()
            {
                Id = pos.Id,
                PostCode = pos.PostCode
            })
        });
        if (items.Count() == 0)
            return null;
        return items;
    }
}
