namespace Yoda.Services.Customer.Entities;

public class ProductEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public IEnumerable<OrderDetailEntity> OrderDetails { get; set; }
}
