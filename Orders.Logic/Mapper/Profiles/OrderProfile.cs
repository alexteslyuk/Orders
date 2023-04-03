using AutoMapper;
using Orders.Domain.Models;
using Orders.Logic.DTOs;

namespace Orders.Logic.Mapper.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
        }
    }
}
