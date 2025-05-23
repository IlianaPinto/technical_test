using Microsoft.EntityFrameworkCore;
using service_api.Entities;

namespace service_api.Context
{
    public class DBContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }

        public DBContext(DbContextOptions<DbContext> options)
        : base(options)
        {
        }
    }
}
