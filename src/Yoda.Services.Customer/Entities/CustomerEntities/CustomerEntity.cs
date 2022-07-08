namespace Yoda.Services.Customer.Entities
{
    public class CustomerEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<OrderEntity> Orders { get; set; }
        public AddressEntity Address { get; set; }
    }
}
