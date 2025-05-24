using service_api.DTOs;

namespace service_api.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetAll();
        Task<OrderDTO?> GetById(Guid id);
        Task<OrderCreateDTO> Create(OrderCreateDTO dto);
        Task<OrderUpdateDTO?> Update(Guid id, OrderUpdateDTO dto);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<OrdersSummaryDTO>> GetOrderSummary();
    }
}
