namespace service_api.DTOs
{
    public class OrdersSummaryDTO
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } = default!;
        public int TotalOrders { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? LastOrderDate { get; set; }
    }
}
