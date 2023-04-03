using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Domain.Models;
using Orders.Domain.Repositories;
using Orders.Logic.Commands;
using Orders.Logic.DTOs;
using Orders.Logic.Queries;
using System.Linq;

namespace Orders.Logic.Handlers
{
    public class OrdersHandlers :
        IRequestHandler<GetOrders, IEnumerable<OrderDTO>>,
        IRequestHandler<GetOrder, OrderDTO>,
        IRequestHandler<GetDistinctNumbers, IEnumerable<string>>,
        IRequestHandler<SaveOrder, int>,
        IRequestHandler<RemoveOrder, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IMapper _mapper;

        public OrdersHandlers(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IProviderRepository providerRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _providerRepository = providerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDTO>> Handle(GetOrders request, CancellationToken cancellationToken)
        {
            var ordersQueryable = _orderRepository
                .GetAll()
                .Where(o => o.Date >= DateTime.SpecifyKind(request.StartDate, DateTimeKind.Utc) && o.Date <= DateTime.SpecifyKind(request.EndDate, DateTimeKind.Utc))
                .ProjectTo<OrderDTO>(_mapper.ConfigurationProvider);
            if (request.Numbers.Any())
                ordersQueryable = ordersQueryable.Where(o => request.Numbers.Contains(o.Number));
            if (request.Providers.Any())
                ordersQueryable = ordersQueryable.Where(o => request.Providers.Contains(o.ProviderId));
            var orders = await ordersQueryable.ToListAsync(cancellationToken);
            foreach (var order in orders)
            {
                order.ProviderName = (await _providerRepository.Get(order.ProviderId)).Name;
            }
            return orders;
        }

        public async Task<OrderDTO> Handle(GetOrder request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<OrderDTO>(await _orderRepository.Get(request.Id));
            order.ProviderName = (await _providerRepository.Get(order.ProviderId)).Name;
            var items = _orderItemRepository
                .GetAll()
                .Where(i => i.OrderId == request.Id)
                .ProjectTo<OrderItemDTO>(_mapper.ConfigurationProvider);
            if (request.Names.Any())
                items = items.Where(i => request.Names.Contains(i.Name));
            if (request.Units.Any())
                items = items.Where(i => request.Units.Contains(i.Unit));
            order.Items = await items.ToListAsync(cancellationToken);
            return order;
        }

        public async Task<IEnumerable<string>> Handle(GetDistinctNumbers request, CancellationToken cancellationToken)
        {
            return await _orderRepository
                .GetAll()
                .Select(o => o.Number)
                .Distinct()
                .ToListAsync(cancellationToken);
        }

        public async Task<int> Handle(SaveOrder request, CancellationToken cancellationToken)
        {
            if (request.Items.Any(i => i.Name == request.Number))
                throw new Exception("Item name should not be equal to the order number!");
            Order order;
            if (request.Id != null)
            {
                order = await _orderRepository.Get((int)request.Id);
                order.Update(request.Number, DateTime.SpecifyKind(request.Date, DateTimeKind.Utc), request.ProviderId);
                _orderRepository.Update(order);
                foreach (var item in await _orderItemRepository.GetAll().Where(i => i.OrderId == request.Id).ToListAsync(cancellationToken))
                {
                    _orderItemRepository.Remove(item);
                }
                await _orderItemRepository.SaveChanges();
            }
            else
            {
                order = await _orderRepository.Add(new Order(request.Number, DateTime.SpecifyKind(request.Date, DateTimeKind.Utc), request.ProviderId));
            }
            await _orderRepository.SaveChanges();
            foreach (var item in request.Items)
            {
                await _orderItemRepository.Add(new OrderItem(order.Id, item.Name, item.Quantity, item.Unit));
            }
            await _orderItemRepository.SaveChanges();
            return order.Id;
        }

        public async Task<int> Handle(RemoveOrder request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.Get(request.Id);
            _orderRepository.Remove(order);
            await _orderRepository.SaveChanges();
            var items = _orderItemRepository.GetAll().Where(i => i.OrderId == request.Id);
            foreach (var item in items)
            {
                _orderItemRepository.Remove(item);
            }
            await _orderRepository.SaveChanges();
            return order.Id;
        }
    }
}
