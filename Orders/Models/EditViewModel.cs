using Orders.Logic.DTOs;

namespace Orders.Models
{
    public class EditViewModel
    {
        public IEnumerable<ProviderDTO> Providers { get; set; }
        public OrderDTO Order { get; set; }
        public IList<OrderItemDTO> Items { get; set; } = new List<OrderItemDTO>();
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
    }
}
