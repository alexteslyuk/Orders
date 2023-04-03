namespace Orders.Domain.Models
{
    public class OrderItem
    {
        public int Id { get; }
        public int OrderId { get; private set; }
        public string Name { get; private set; }
        public decimal Quantity { get; private set; }
        public string Unit { get; private set; }

        public OrderItem()
        {
        }

        public OrderItem (int orderId, string name, decimal quantity, string unit)
        {
            OrderId = orderId;
            Name = name ?? string.Empty;
            Quantity = quantity;
            Unit = unit ?? string.Empty;
        }
    }
}
