using service_api.DTOs;
using service_api.Entities;
using service_api.Repository;

namespace service_api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderRepository repo, ILogger<OrderService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            var orders = await _repo.GetAll();
            return orders.Select(o => new OrderDTO
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                CustomerName = o.Customer.Name,
                OrderDate = o.OrderDate,
                Status = o.Status,
                Total = o.Total
            });
        }

        public async Task<OrderDTO?> GetById(Guid id)
        {
            var order = await _repo.GetById(id);
            if (order == null) return null;

            return new OrderDTO
            {
                Id = order.Id,
                CustomerName = order.Customer.Name,
                OrderDate = order.OrderDate,
                Status = order.Status,
                Total = order.Total
            };
        }

        public async Task<OrderCreateDTO> Create(OrderCreateDTO dto)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = dto.CustomerId,
                OrderDate = dto.OrderDate,
                Status = dto.Status,
                Total = dto.Total
            };

            await _repo.Create(order);

            _logger.LogInformation("Order created with ID {Id}", order.Id);

            return new OrderCreateDTO
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                Status = order.Status,
                Total = order.Total
            };
        }

        public async Task<OrderUpdateDTO?> Update(Guid id, OrderUpdateDTO dto)
        {
            var existing = await _repo.GetById(id);
            if (existing == null) return null;

            existing.Status = dto.Status;
            existing.Total = dto.Total;

            await _repo.Update(existing);

            _logger.LogInformation("Order with ID {Id} updated", existing.Id);

            return new OrderUpdateDTO
            {
                Status = existing.Status,
                Total = existing.Total
            };
        }

        public async Task<bool> Delete(Guid id)
        {
            var existing = await _repo.GetById(id);
            if (existing == null) return false;

            await _repo.Delete(existing);

            _logger.LogInformation("Order with ID {Id} deleted", existing.Id);
            return true;
        }

        public async Task<IEnumerable<OrdersSummaryDTO>> GetOrderSummary()
        {
            var summary = await _repo.GetOrderSummary();
            return summary;
        }
    }
}
