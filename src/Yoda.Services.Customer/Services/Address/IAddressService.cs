using Yoda.Services.Customer.Models;

namespace Yoda.Services.Customer.Services.Country;

public interface IAddressService
{
    int Create(AddressModel address);
}
