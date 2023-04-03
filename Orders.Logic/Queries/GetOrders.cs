using MediatR;
using Orders.Logic.DTOs;

namespace Orders.Logic.Queries
{
    public class GetOrders : IRequest<IEnumerable<OrderDTO>>
    {
        public IEnumerable<string> Numbers { get; set; }
        public IEnumerable<int> Providers { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
