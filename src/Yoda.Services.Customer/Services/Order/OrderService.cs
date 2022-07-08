using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Yoda.Services.Customer.Data;
using Yoda.Services.Customer.Entities;
using Yoda.Services.Customer.Models;

namespace Yoda.Services.Customer.Services.Order;

public class OrderService : IOrderService
{
    private readonly YodaContext _yodaContext;
    private readonly IMapper _mapper;

    public OrderService(YodaContext yodaContext, IMapper mapper)
    {
        _yodaContext = yodaContext;
        _mapper = mapper;
    }

    public IEnumerable<OrderModel> Get(int start = 0, int length = 10)
    {
        var items = _yodaContext.Orders.Skip(start).Take(length).Select(item => new OrderModel()
        {
            Id = item.Id,
            CustomerId = item.CustomerId,
            CreateDateUTC = item.CreateDateUTC
        });
        if (items == null)
            return null;
        return items;
    }

    public OrderModel GetById(int id)
    {
        var item = _yodaContext.Orders.FirstOrDefault(x => x.Id == id);
        if (item == null)
            return null;
        return new OrderModel()
        {
            Id = item.Id,
            CustomerId = item.CustomerId,
            CreateDateUTC = item.CreateDateUTC
        };
    }

    public IEnumerable<OrdersByCustomerIdModel> GetOrdersOfCustomer(int id)
    {
        return _yodaContext
            .Customers
            .AsNoTracking()
            .Where(cus => cus.Id == id)
            .Select(cus => new OrdersByCustomerIdModel()
            {
                Id = cus.Id,
                Name = cus.Name,
                Orders = cus.Orders
                .Select(order => new OrderDetailByOrderIdModel()
                {
                    Id = order.Id,
                    CreateDateUtc = order.CreateDateUTC,
                    Products = order.OrderDetails.Select(odt => new ProductModel()
                    {
                        Id = odt.Product.Id,
                        Name = odt.Product.Name
                    })
                })
            });
    }

    public int Create(OrderModel order)
    {
        var item = _mapper.Map<OrderEntity>(order);
        _yodaContext.Orders.Add(item);
        _yodaContext.SaveChanges();
        return item.Id;
    }

    public void Update(int orderId, OrderEntity order)
    {
        var item = _yodaContext.Orders.FirstOrDefault(s => s.Id == orderId);
        if (item != null)
        {
            item.CustomerId = item.CustomerId;
            _yodaContext.Orders.Update(item);
            _yodaContext.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var order = _yodaContext.Orders.FirstOrDefault(s => s.Id == id);
        if (order != null)
        {
            _yodaContext.Orders.Remove(order);
            _yodaContext.SaveChanges();
        }
    }
}
