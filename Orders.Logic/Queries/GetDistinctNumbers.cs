using MediatR;

namespace Orders.Logic.Queries
{
    public class GetDistinctNumbers: IRequest<IEnumerable<string>>
    {
    }
}
