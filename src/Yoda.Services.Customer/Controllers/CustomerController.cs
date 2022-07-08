using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Customer.Models;
using Yoda.Services.Customer.Services.Customer;
using Yoda.Services.Customer.Entities;
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
        var result = CustomerService.GetList(start, length);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet("{customerId}")]
    public IActionResult Get([FromRoute] int id)
    {
        var result = CustomerService.GetById(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CustomerModel customer)
    {
        var result = CustomerService.Create(customer);
        return Ok(result);
    }

    [HttpPut("{customerId}")]
    public IActionResult Put([FromRoute] int id, [FromBody] CustomerEntity customer)
    {
        CustomerService.Update(id, customer);
        return Ok();
    }

    [HttpDelete("{customerId}")]
    public IActionResult Delete([FromRoute] int id)
    {
        CustomerService.Delete(id);
        return NoContent();
    }
}
