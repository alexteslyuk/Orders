using MediatR;

namespace Orders.Logic.Queries
{
    public class GetDistinctUnits : IRequest<IEnumerable<string>>
    {
        public int OrderId { get; set; }
    }
}
