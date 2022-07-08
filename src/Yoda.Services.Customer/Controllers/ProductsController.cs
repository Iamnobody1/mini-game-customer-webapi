using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Customer.Models;
using Yoda.Services.Customer.Services.Product;

namespace Yoda.Services.Customer.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int start, [FromQuery] int length)
    {
        var item = _productService.GetList(start, length);
        if (item == null || !item.Any())
            return NotFound();
        return Ok(item);
    }

    [HttpGet("{productId}")]
    public IActionResult Get([FromRoute] int id)
    {
        var item = _productService.GetById(id);
        if (item == null)
            return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public IActionResult Post([FromBody] ProductModel product)
    {
        var item = _productService.Create(product);
        return Ok(item);
    }

    [HttpPut("{productId}")]
    public IActionResult Put([FromRoute] int id, [FromBody] ProductModel product)
    {
        _productService.Update(id, product);
        return Ok();
    }

    [HttpDelete("{productId}")]
    public IActionResult Delete([FromRoute] int productId)
    {
        _productService.Delete(productId);
        return NoContent();
    }
}
