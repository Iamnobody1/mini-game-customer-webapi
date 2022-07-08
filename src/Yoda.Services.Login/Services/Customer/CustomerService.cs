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

        public CustomerModel Login(int id)
        {
            var item = _yodaContext.Customers.FirstOrDefault(c => c.Id == id);
            if (item == null)
            {
                return null;
            }
            return new CustomerModel() { Id = item.Id, Name = item.Name };
        }
    }
}
