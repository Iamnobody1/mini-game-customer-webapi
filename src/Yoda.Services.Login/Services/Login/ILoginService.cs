using Yoda.Services.Login.Models;

namespace Yoda.Services.Login.Services.Login;

public interface ILoginService
{
    Task<bool> Login(CustomerModel customer);
}
