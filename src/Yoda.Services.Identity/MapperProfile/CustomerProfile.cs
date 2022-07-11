using AutoMapper;

namespace Yoda.Services.Identity.MapperProfile;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerModel, CustomerEntity>();
    }
}
