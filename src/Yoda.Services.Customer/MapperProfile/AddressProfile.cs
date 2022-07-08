using AutoMapper;
using Yoda.Services.Customer.Entities;
using Yoda.Services.Customer.Models;

namespace Yoda.Services.Customer.MapperProfile;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<AddressModel, AddressEntity>();
    }
}
