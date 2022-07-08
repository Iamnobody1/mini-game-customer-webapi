using AutoMapper;
using Yoda.Services.Customer.Entities;
using Yoda.Services.Register.Models;

namespace Yoda.Services.Register.MapperProfile
{
    public class RegisterProfile : Profile
    {
        public RegisterProfile()
        {
            CreateMap<CustomerModel, CustomerEntity>().ReverseMap();
        }
    }
}
