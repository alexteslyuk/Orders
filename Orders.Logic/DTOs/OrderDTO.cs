namespace Orders.Logic.DTOs
{
    public class OrderDTO
    {
        public int? Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public List<OrderItemDTO> Items { get; set; } = new List<OrderItemDTO>();
    }
}
