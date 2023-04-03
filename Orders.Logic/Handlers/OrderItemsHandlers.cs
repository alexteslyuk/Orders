using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Domain.Repositories;
using Orders.Logic.Queries;

namespace Orders.Logic.Handlers
{
    public class OrderItemsHandlers :
        IRequestHandler<GetDistinctNames, IEnumerable<string>>,
        IRequestHandler<GetDistinctUnits, IEnumerable<string>>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemsHandlers(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<string>> Handle(GetDistinctNames request, CancellationToken cancellationToken)
        {
            return await _orderItemRepository
                .GetAll()
                .Where(i => i.OrderId == request.OrderId)
                .Select(i => i.Name)
                .Distinct()
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<string>> Handle(GetDistinctUnits request, CancellationToken cancellationToken)
        {
            return await _orderItemRepository
                .GetAll()
                .Where(i => i.OrderId == request.OrderId)
                .Select(i => i.Unit)
                .Distinct()
                .ToListAsync(cancellationToken);
        }
    }
}
