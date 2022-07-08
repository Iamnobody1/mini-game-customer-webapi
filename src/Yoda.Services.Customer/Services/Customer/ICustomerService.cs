using Yoda.Services.Customer.Models;
using Yoda.Services.Customer.Entities;
namespace Yoda.Services.Customer.Services.Customer
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> GetList(int start = 0, int lenght = 2);
        int Create(CustomerModel customer);
        CustomerModel GetById(int customerId);
        void Update(int id, CustomerEntity cus);
        void Delete(int id);

    }
}
