using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Customer.Services.District;

namespace Yoda.Services.Customer.Controllers;

[ApiController]
[Route("[controller]")]
public class DistrictsController : ControllerBase
{
    private readonly IDistrictService _districtService;

    public DistrictsController(IDistrictService districtService)
    {
        _districtService = districtService;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int id)
    {
        var result = _districtService.GetList(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
}
