using MediatR;
using Orders.Logic.DTOs;

namespace Orders.Logic.Queries
{
    public class GetProviders : IRequest<IEnumerable<ProviderDTO>>
    {
    }
}
