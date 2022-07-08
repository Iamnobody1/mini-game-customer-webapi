using AutoMapper;
using Yoda.Services.Login.Entities;
using Yoda.Services.Login.Models;

namespace Yoda.Services.Login.MapperProfile;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerModel, CustomerEntity>();
    }
}
