using AutoMapper;
using Yoda.Services.Login.Data;
using Yoda.Services.Login.Entities;
using Yoda.Services.Login.Models;

namespace Yoda.Services.Login.Services.Login;

public class LoginService : ILoginService
{
    private readonly YodaContext _yodaContext;
    private readonly IMapper _mapper;

    public LoginService(YodaContext yodaContext, IMapper mapper)
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
