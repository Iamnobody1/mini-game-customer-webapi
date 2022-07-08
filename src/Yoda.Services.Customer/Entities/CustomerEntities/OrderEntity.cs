namespace Yoda.Services.Customer.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset CreateDateUTC { get; set; }

        public CustomerEntity Customer { get; set; }
        public IEnumerable<OrderDetailEntity> OrderDetails { get; set; }
    }
}
