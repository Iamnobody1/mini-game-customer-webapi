using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Customer.Services.District;

namespace Yoda.Services.Customer.Controllers;

[ApiController]
[Route("[controller]")]
public class SubDistrictsController : ControllerBase
{
    private readonly ISubDistrictService _subDistrictService;

    public SubDistrictsController(ISubDistrictService subDistrictService)
    {
        _subDistrictService = subDistrictService;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int id)
    {
        var result = _subDistrictService.GetList(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
}
