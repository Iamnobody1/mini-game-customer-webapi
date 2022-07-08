namespace Yoda.Services.Customer.Entities
{
    public class OrderDetailEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public OrderEntity Order { get; set; }
        public ProductEntity Product { get; set; }
    }
}
