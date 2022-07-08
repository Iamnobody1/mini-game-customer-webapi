using AutoMapper;
using Yoda.Services.Customer.Data;
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

    public bool Login(CustomerModel customer)
    {
        var item = _yodaContext.Customers.FirstOrDefault(c => c.Username == customer.Username && c.Password == customer.Password);
        if (item == null)
        {
            return false;
        }
        return true;
    }
}
