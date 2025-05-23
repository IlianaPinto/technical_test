namespace service_api.Entities
{
    public enum OrderStatus
    {
        Pending = 0,
        Processing = 1,
        Shipped = 2,
        Delivered = 3,
        Cancelled = 4
    }

    public class Order
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public OrderStatus Status { get; set; } = 0; 
        public decimal Total { get; set; }
        public Customer Customer { get; set; } = default!;
    }
}
