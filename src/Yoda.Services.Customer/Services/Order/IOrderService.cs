using Yoda.Services.Customer.Entities;
using Yoda.Services.Customer.Models;

namespace Yoda.Services.Customer.Services.Order;

public interface IOrderService
{
    IEnumerable<OrderModel> Get(int start = 0, int length = 10);
    OrderModel GetById(int orderId);
    IEnumerable<OrdersByCustomerIdModel> GetOrdersOfCustomer(int id);
    int Create(OrderModel newOrder);
    void Update(int orderId, OrderEntity newOrder);
    void Delete(int orderId);
}
