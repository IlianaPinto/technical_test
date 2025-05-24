using Microsoft.EntityFrameworkCore;
using service_api.Context;
using service_api.DTOs;
using service_api.Entities;
using System;

namespace service_api.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DBContext _context;

        public OrderRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Order.Include(o => o.Customer).ToListAsync();
        }

        public async Task<Order?> GetById(Guid id)
        {
            return await _context.Order.FindAsync(id);
        }

        public async Task Create(Order order)
        {
            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Order order)
        {
            _context.Order.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Order order)
        {
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrdersSummaryDTO>> GetOrderSummary()
        {
            return await _context.Order
                .Include(o => o.Customer)
                .GroupBy(o => new { o.CustomerId, o.Customer.Name })
                .Select(g => new OrdersSummaryDTO
                {
                    CustomerId = g.Key.CustomerId,
                    CustomerName = g.Key.Name,
                    TotalOrders = g.Count(),
                    TotalAmount = g.Sum(o => o.Total),
                    LastOrderDate = g.Max(o => o.OrderDate)
                })
                .ToListAsync();
        }
    }
}
