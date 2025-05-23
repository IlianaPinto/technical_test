using Microsoft.EntityFrameworkCore;
using service_api.Entities;

namespace service_api.Context
{
    public class DBContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<User> User { get; set; }

        public DBContext(DbContextOptions<DBContext> options)
        : base(options)
        {
        }
    }
}
