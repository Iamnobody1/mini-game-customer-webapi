using Yoda.Services.Login.Models;

namespace Yoda.Services.Login.Services.Login;

public interface ILoginService
{
    Task<Guid> Login(CustomerModel customer);
}
