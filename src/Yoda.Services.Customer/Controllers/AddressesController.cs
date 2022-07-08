using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Customer.Models;
using Yoda.Services.Customer.Services.Country;

namespace Yoda.Services.Customer.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressesController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressesController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpPost]
    public IActionResult Post([FromBody] AddressModel address)
    {
        var result = _addressService.Create(address);
        return Ok(result);
    }
}
