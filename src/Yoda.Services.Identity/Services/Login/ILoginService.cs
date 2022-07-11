using Yoda.Services.Login.Models;

namespace Yoda.Services.Identity.Services.Login;

public interface ILoginService
{
    Task<string> Login(CustomerModel customer);
}
