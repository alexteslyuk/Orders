using MediatR;

namespace Orders.Logic.Commands
{
    public class RemoveOrder : IRequest<int>
    {
        public int Id { get; set; }
    }
}
