using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Yoda.Services.Identity.Services.Login;

public class LoginService : ILoginService
{
    private readonly YodaContext _yodaContext;
    private readonly IMapper _mapper;

    public LoginService(YodaContext yodaContext, IMapper mapper)
    {
        _yodaContext = yodaContext;
        _mapper = mapper;
    }

    public async Task<Guid> Login(CustomerModel customer)
    {
        var item = await _yodaContext.Customers
            .FirstOrDefaultAsync(x =>
                x.Username == customer.Username &&
                x.Password == customer.Password
            );
        if (item == null)
        {
            return Guid.Empty;
        }
        return item.Id;
    }
}
