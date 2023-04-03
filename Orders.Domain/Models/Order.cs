namespace Orders.Domain.Models
{
    public class Order
    {
        public int Id { get; }
        public string Number { get; private set; }
        public DateTime Date { get; private set; }
        public int ProviderId { get; private set; }

        public Order()
        {
        }

        public Order(string number, DateTime date, int providerId)
        {
            Number = number;
            Date = date;
            ProviderId = providerId;
        }

        public void Update(string number, DateTime date, int providerId)
        {
            Number = number;
            Date = date;
            ProviderId = providerId;
        }
    }
}
