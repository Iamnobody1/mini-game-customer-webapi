namespace Yoda.Services.Customer.Models;

public class OrderModel
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTimeOffset CreateDateUTC { get; set; }
}


