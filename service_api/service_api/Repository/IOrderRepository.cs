using service_api.Entities;

namespace service_api.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order?> GetById(Guid id);
        Task Create(Order order);
        Task Update(Order order);
        Task Delete(Order order);
    }
}
