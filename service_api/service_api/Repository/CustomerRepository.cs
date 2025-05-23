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
    }
}
