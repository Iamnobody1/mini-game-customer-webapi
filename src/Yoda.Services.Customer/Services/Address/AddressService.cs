using AutoMapper;
using Yoda.Services.Customer.Data;
using Yoda.Services.Customer.Entities;
using Yoda.Services.Customer.Models;

namespace Yoda.Services.Customer.Services.Country;

public class AddressService : IAddressService
{
    private readonly YodaContext _yodaContext;
    private readonly IMapper _mapper;

    public AddressService(YodaContext yodaContext, IMapper mapper)
    {
        _yodaContext = yodaContext;
        _mapper = mapper;
    }

    public int Create(AddressModel address)
    {
        var item = _mapper.Map<AddressEntity>(address);
        _yodaContext.Addresses.Add(item);
        _yodaContext.SaveChanges();
        return item.Id;
    }
}
