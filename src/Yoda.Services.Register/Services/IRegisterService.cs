using Yoda.Services.Register.Models;

namespace Yoda.Services.Register.Services
{
    public interface IRegisterService
    {
        Task<Tuple<Guid, string>> Create(CustomerModel customer);
        Task Delete(Guid id);
        Task<CustomerModel> GetByGuidId(Guid id);
        Task<IEnumerable<CustomerModel>> GetListByGuid(Guid id);
        Task Update(Guid id, CustomerModel customer);
    }
}