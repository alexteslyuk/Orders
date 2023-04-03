using AutoMapper;
using Orders.Domain.Models;
using Orders.Logic.DTOs;

namespace Orders.Logic.Mapper.Profiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<OrderItemDTO, OrderItem>();
        }
    }
}
