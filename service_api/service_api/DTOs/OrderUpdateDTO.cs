namespace service_api.DTOs
{
    public class OrderUpdateDTO
    {
        public string Status { get; set; } = default!;
        public decimal Total { get; set; }
    }
}
