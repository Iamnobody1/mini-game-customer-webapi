using AutoMapper;
using Yoda.Services.Customer.Data;

using Yoda.Services.Customer.Entities;
using Yoda.Services.Customer.Models;

namespace Yoda.Services.Customer.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly YodaContext _yodaContext;
        private readonly IMapper _mapper;

        public CustomerService(YodaContext yodaContext, IMapper mapper)
        {
            _yodaContext = yodaContext;
            _mapper = mapper;
        }


        public int Create(CustomerModel customer)
        {
            var item = _mapper.Map<CustomerEntity>(customer);
            _yodaContext.Customers.Add(item);
            _yodaContext.SaveChanges();
            return item.Id;
        }

        public CustomerModel GetById(int id)
        {
            var item = _yodaContext.Customers.FirstOrDefault(c => c.Id == id);
            if (item == null)
            {
                return null;
            }
            return new CustomerModel() { Id = item.Id, Name = item.Name };
        }

        public IEnumerable<CustomerModel> GetList(int start = 0, int lenght = 2)
        {
            var item = _yodaContext.Customers.Skip(start).Take(lenght).Select(item => new CustomerModel() { Id = item.Id, Name = item.Name });
            return item;
        }

        public void Update(int id, CustomerEntity customer)
        {
            var item = _yodaContext.Customers.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                item.Name = customer.Name;
                _yodaContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var item = _yodaContext.Customers.FirstOrDefault(d => d.Id == id);
            if (item != null)
            {
                _yodaContext.Customers.Remove(item);
                _yodaContext.SaveChanges();
            }
        }
    }
}
