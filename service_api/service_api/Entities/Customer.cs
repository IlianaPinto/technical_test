namespace service_api.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
