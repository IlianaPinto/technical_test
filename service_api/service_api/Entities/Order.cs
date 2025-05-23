namespace service_api.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending"; 
        public decimal Total { get; set; }
        public Customer Customer { get; set; } = default!;
    }
}
