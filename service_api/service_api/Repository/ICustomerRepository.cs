using service_api.Entities;

namespace service_api.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll();
    }
}
