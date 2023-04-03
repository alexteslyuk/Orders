using MediatR;
using Orders.Logic.DTOs;

namespace Orders.Logic.Queries
{
    public class GetOrder : IRequest<OrderDTO>
    {
        public int Id { get; set; }
        public IEnumerable<string> Names { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<string> Units { get; set; } = Enumerable.Empty<string>();
    }
}
