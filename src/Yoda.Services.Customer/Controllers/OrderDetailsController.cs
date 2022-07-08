using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Customer.Models;
using Yoda.Services.Customer.Services.OrderDetailsService;

namespace Yoda.Services.Customer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _orderDetailsService;

        public OrderDetailsController(IOrderDetailsService orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
        }

        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            var result = _orderDetailsService.GetById(Id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("")]
        public IActionResult GetList([FromQuery] int start, [FromQuery] int length)
        {
            var result = _orderDetailsService.GetList(start, length);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrderDetailModel orderdetails)
        {
            var result = _orderDetailsService.Create(orderdetails);
            return Ok(result);
        }

        [HttpPut("{Id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] OrderDetailModel orderdetail)
        {
            _orderDetailsService.Update(id, orderdetail);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _orderDetailsService.Delete(id);
            return NoContent();
        }
    }
}
