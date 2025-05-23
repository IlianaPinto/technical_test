using Microsoft.AspNetCore.Identity;
using service_api.Context;
using service_api.Entities;

namespace service_api.Data
{
    public class SeedData
    {
        public static void Initialize(DBContext context)
        {
            if (!context.User.Any())
            {
                var hasher = new PasswordHasher<User>();

                var admin = new User
                {
                    Email = "admin@example.com",
                    Role = "Admin",
                };
                admin.PasswordHash = hasher.HashPassword(admin, "Admin123");

                var user = new User
                {
                    Email = "user@example.com",
                    Role = "User",
                };
                user.PasswordHash = hasher.HashPassword(user, "User123");
                context.User.AddRange(admin, user);
                context.SaveChanges();

            }

            if (!context.Customer.Any())
            {
                var customer1 = new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Armando Paredes",
                    Email = "armando.paredes@example.com",
                    PhoneNumber = "555-1234",
                    Date = DateTime.UtcNow
                };

                var customer2 = new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Elsa Pato",
                    Email = "elsa.pato@example.com",
                    PhoneNumber = null,
                    Date = DateTime.UtcNow
                };

                context.Customer.AddRange(customer1, customer2);
                context.SaveChanges();


                var order1 = new Order
                {
                    Id = Guid.NewGuid(),
                    CustomerId = customer1.Id,
                    OrderDate = DateTime.UtcNow.AddDays(-3),
                    Status = "Completed",
                    Total = 120.50m,
                };

                var order2 = new Order
                {
                    Id = Guid.NewGuid(),
                    CustomerId = customer1.Id,
                    OrderDate = DateTime.UtcNow.AddDays(-1),
                    Status = "Pending",
                    Total = 75.00m,
                };

                var order3 = new Order
                {
                    Id = Guid.NewGuid(),
                    CustomerId = customer2.Id,
                    OrderDate = DateTime.UtcNow.AddDays(-2),
                    Status = "Pending",
                    Total = 200.00m,
                };
                context.Order.AddRange(order1, order2, order3);
                context.SaveChanges();


            }

        }
    }
}
