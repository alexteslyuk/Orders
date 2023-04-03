using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Domain.Repositories;
using Orders.Logic.DTOs;
using Orders.Logic.Queries;

namespace Orders.Logic.Handlers
{
    public class GetProvidersHandler : IRequestHandler<GetProviders, IEnumerable<ProviderDTO>>
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IMapper _mapper;

        public GetProvidersHandler(IProviderRepository providerRepository, IMapper mapper)
        {
            _providerRepository = providerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProviderDTO>> Handle(GetProviders request, CancellationToken cancellationToken)
        {
            return await _providerRepository
                .GetAll()
                .ProjectTo<ProviderDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
