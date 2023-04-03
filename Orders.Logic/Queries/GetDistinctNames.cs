using MediatR;

namespace Orders.Logic.Queries
{
    public class GetDistinctNames : IRequest<IEnumerable<string>>
    {
        public int OrderId { get; set; }
    }
}
