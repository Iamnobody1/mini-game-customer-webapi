using AutoMapper;
using Yoda.Services.Customer.Data;
using Yoda.Services.Customer.Entities;
using Yoda.Services.Customer.Models;

namespace Yoda.Services.Customer.Services.Customer;

public class CustomerService : ICustomerService
{
    private readonly YodaContext _yodaContext;
    private readonly IMapper _mapper;

    public CustomerService(YodaContext yodaContext, IMapper mapper)
    {
        _yodaContext = yodaContext;
        _mapper = mapper;
    }

    public async Task<bool> Login(CustomerModel customer)
    {
        var item = _mapper.Map<CustomerEntity>(customer);
        if (item == null)
        {
            return false;
        }
        return true;
    }
}
