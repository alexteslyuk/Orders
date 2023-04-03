namespace Orders.Domain.Models
{
    public class Provider
    {
        public int Id { get; }
        public string Name { get; private set; }

        public Provider()
        {
        }

        public Provider(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
