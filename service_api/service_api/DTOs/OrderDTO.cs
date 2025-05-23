namespace service_api.DTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = default!;
        public decimal Total { get; set; }
    }
}
