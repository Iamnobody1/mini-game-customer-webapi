namespace Yoda.Services.Customer.Models
{
    public class OrdersByCustomerIdModel : CustomerModel
    {
        public IEnumerable<OrderDetailByOrderIdModel> Orders { get; set; }
    }
}
