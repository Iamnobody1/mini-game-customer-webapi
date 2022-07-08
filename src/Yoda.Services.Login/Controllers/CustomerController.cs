using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Login.Models;
using Yoda.Services.Login.Services.Login;

namespace Yoda.Services.Login.Controllers;

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
        if (!result)
            return NotFound();
        return Ok(result);
    }
}
