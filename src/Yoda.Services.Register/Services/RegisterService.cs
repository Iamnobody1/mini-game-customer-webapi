using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Yoda.Services.Customer.Data;
using Yoda.Services.Customer.Entities;
using Yoda.Services.Register.Models;

namespace Yoda.Services.Register.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly YodaContext _yodaContext;
        private readonly IMapper _mapper;

        public RegisterService(YodaContext yodaContext, IMapper mapper)
        {
            _yodaContext = yodaContext;
            _mapper = mapper;
        }

        public async Task<CustomerModel> GetByGuidId(Guid id)
        {
            var item = await _yodaContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (item == null)
            {
                return null;
            }
            return _mapper.Map<CustomerModel>(item);
        }

        public async Task<IEnumerable<CustomerModel>> GetListByGuid(Guid id)
        {
            var item = await _yodaContext.Customers
                .Where(m => m.Id == id)
                .ToListAsync();

            if (item == null)
                return null;
            return _mapper.Map<IEnumerable<CustomerModel>>(item);
        }

        public async Task<Guid> Create(CustomerModel customer)
        {
            var item = _mapper.Map<CustomerEntity>(customer);
            await _yodaContext.Customers.AddAsync(item);
            await _yodaContext.SaveChangesAsync();
            return item.Id;
        }
        public async Task Update(Guid id, CustomerModel customer)
        {
            customer.Id = id;
            var item = await _yodaContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (item != null)
            {
               var x = _mapper.Map<CustomerModel,CustomerEntity>(customer,item);
                _yodaContext.Customers.Attach(item);
                await _yodaContext.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var item = await _yodaContext.Customers.FirstOrDefaultAsync(d => d.Id == id);
            if (item != null)
            {
                _yodaContext.Customers.Remove(item);
                await _yodaContext.SaveChangesAsync();
            }
        }

    }
}