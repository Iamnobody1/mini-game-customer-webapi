using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Customer.Entities;
using Yoda.Services.Customer.Models;
using Yoda.Services.Customer.Services.Customer;

namespace Yoda.Services.Customer.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService CustomerService;

    public CustomersController(ICustomerService customerService)
    {
        CustomerService = customerService;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int start, [FromQuery] int length)
    {
        var result = CustomerService.Login(start, length);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
}
