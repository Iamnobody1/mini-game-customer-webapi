using Yoda.Services.Customer.Models;

namespace Yoda.Services.Customer.Services.Customer;

public interface ICustomerService
{
    bool Login(CustomerModel customer);
}
