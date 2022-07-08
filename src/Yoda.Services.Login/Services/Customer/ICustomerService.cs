using Yoda.Services.Customer.Models;

namespace Yoda.Services.Customer.Services.Customer;

public interface ICustomerService
{
    Task<bool> Login(CustomerModel customer);
}
