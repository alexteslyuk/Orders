using MediatR;
using Orders.Logic.DTOs;

namespace Orders.Logic.Commands
{
    public class SaveOrder : IRequest<int>
    {
        public int? Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
        public IList<OrderItemDTO> Items { get; set;}
    }
}
