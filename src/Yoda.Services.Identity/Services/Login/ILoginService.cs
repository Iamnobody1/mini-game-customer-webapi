using Yoda.Services.Login.Models;

namespace Yoda.Services.Identity.Services.Login;

public interface ILoginService
{
    Task<JwtTokenModel> Login(CustomerModel customer);
}
