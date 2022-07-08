using AutoMapper;
using Yoda.Services.Customer.Entities;

namespace Yoda.Services.Customer.Models
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressModel, AddressEntity>();
        }
    }
}
