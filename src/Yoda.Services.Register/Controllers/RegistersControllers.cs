using System;
using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Customer.Entities;
using Yoda.Services.Register.Models;
using Yoda.Services.Register.Services;
namespace Yoda.Services.Register.Controllers;

[ApiController]
[Route("[controller]")]
public class RegistersController : ControllerBase
{
    private readonly IRegisterService _registerService;

    public RegistersController(IRegisterService registerService)
    {
        _registerService = registerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetListByGuid([FromQuery] Guid id)
    {
        var result = await _registerService.GetListByGuid(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByGuidId([FromRoute] Guid id)
    {
        var result = await _registerService.GetByGuidId(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CustomerModel customer)
    {
        var result = await _registerService.Create(customer);
        if(result == Guid.Empty){
            return Conflict();
        }
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] CustomerModel customer)
    {
       await  _registerService.Update(id, customer);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _registerService.Delete(id);
        return NoContent();
    }
}
