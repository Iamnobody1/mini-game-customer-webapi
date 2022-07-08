using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Customer.Entities;
using Yoda.Services.Customer.Models;
using Yoda.Services.Customer.Services.Order;

namespace Yoda.Services.Customer.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService OrderService;

    public OrdersController(IOrderService orderService)
    {
        OrderService = orderService;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int start = 0, [FromQuery] int length = 10)
    {
        var result = OrderService.Get(start, length);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet("{orderId}")]
    public IActionResult Get([FromRoute] int id)
    {
        var result = OrderService.GetById(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost()]
    public IActionResult Post([FromBody] OrderModel order)
    {
        var result = OrderService.Create(order);
        return Ok(result);
    }

    [HttpPut("{orderId}")]
    public IActionResult Put([FromRoute] int id, [FromBody] OrderEntity order)
    {
        OrderService.Update(id, order);
        return Ok();
    }

    [HttpDelete("{orderId}")]
    public IActionResult Delete([FromRoute] int id)
    {
        OrderService.Delete(id);
        return NoContent();
    }
}
