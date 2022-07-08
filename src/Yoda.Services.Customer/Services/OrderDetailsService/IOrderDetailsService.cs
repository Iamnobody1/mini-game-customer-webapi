using Yoda.Services.Customer.Models;

namespace Yoda.Services.Customer.Services.OrderDetailsService
{
    public interface IOrderDetailsService
    {
        OrderDetailModel GetById(int id);
        IEnumerable<OrderDetailModel> GetList(int start = 0, int length = 10);
        int Create(OrderDetailModel orderDetail);
        void Update(int id, OrderDetailModel orderdetail);
        void Delete(int id);

    }
}
