using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Identity.Services.Login;
using Yoda.Services.Login.Models;

namespace Yoda.Services.Identity.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly ILoginService LoginService;

    public LoginController(ILoginService loginService)
    {
        LoginService = loginService;
    }

    [HttpPost]
    public async Task<IActionResult> Get([FromBody] CustomerModel customer)
    {
        var result = await LoginService.Login(customer);
        if (result == Guid.Empty)
            return Unauthorized();
        return Ok(result);
    }
}
