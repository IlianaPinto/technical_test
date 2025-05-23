namespace service_api.DTOs
{
    public class OrderCreateDTO
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending";
        public decimal Total { get; set; }
    }
}
