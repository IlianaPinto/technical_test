using Microsoft.EntityFrameworkCore;
using service_api.Context;
using service_api.Entities;

namespace service_api.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DBContext _context;

        public CustomerRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task<Customer?> GetById(Guid id)
        {
            return await _context.Customer.FindAsync(id);
        }

        public async Task Create(Customer customer)
        {
            await _context.Customer.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Customer customer)
        {
            _context.Customer.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Customer customer)
        {
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
