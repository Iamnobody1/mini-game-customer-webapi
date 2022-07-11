using AutoMapper;
using Yoda.Services.Identity.Entities;
using Yoda.Services.Login.Models;

namespace Yoda.Services.Identity.MapperProfile;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerModel, CustomerEntity>();
    }
}
