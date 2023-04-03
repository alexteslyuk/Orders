using AutoMapper;
using Orders.Domain.Models;
using Orders.Logic.DTOs;

namespace Orders.Logic.Mapper.Profiles
{
    public class ProviderProfile : Profile
    {
        public ProviderProfile()
        {
            CreateMap<Provider, ProviderDTO>();
        }
    }
}
