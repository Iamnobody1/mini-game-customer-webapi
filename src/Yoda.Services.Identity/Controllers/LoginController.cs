using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Identity.Attribute;
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
    public async Task<IActionResult> Post([FromBody] CustomerModel customer)
    {
        var result = await LoginService.Login(customer);
        Console.WriteLine(result);
        if (result.Token == string.Empty)
            return Unauthorized();
        return Ok(result);
    }

    [Authorize]
    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> Get()
    {
        var x = new CustomerModel{
            Id = Guid.NewGuid(),
            Username = "Test1",
            Password = "Test2",
            DisplayName = "Test3",
            Avatar = "Test4"
        };
        return Ok(x);
    }

    [AllowAnonymous]
    [CustomAuthorize]
    [HttpGet]
    [Route("get2")]
    public async Task<IActionResult> Get2()
    {
        
        return Ok();
    }

     private string ipAddress()
    {
        // get source ip address for the current request
        if (Request.Headers.ContainsKey("X-Forwarded-For"))
            return Request.Headers["X-Forwarded-For"];
        else
            return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
    }
}
