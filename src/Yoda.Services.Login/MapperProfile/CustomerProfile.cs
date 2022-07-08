using AutoMapper;
using Yoda.Services.Customer.Entities;
using Yoda.Services.Customer.Models;

namespace Yoda.Services.Customer.MapperProfile;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerModel, CustomerEntity>();
    }
}
