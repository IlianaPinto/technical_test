using service_api.Entities;

namespace service_api.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer?> GetById(Guid id);
        Task Create(Customer customer);
        Task Update(Customer customer);
        Task Delete(Customer customer);
    }
}
