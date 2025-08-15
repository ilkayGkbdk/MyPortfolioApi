using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolioApi.Application.DTOs.Technology;
using MyPortfolioApi.Application.Repositories.Technology;

namespace MyPortfolioApi.Application.Features.Queries.TechnologyQueries.GetAllTechnologies;

public class GetAllTechnologiesQueryHandler : IRequestHandler<GetAllTechnologiesQueryRequest, GetAllTechnologiesQueryResponse>
{
    private readonly ITechnologyReadRepository _readRepository;
    private readonly IMapper _mapper;

    public GetAllTechnologiesQueryHandler(ITechnologyReadRepository readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<GetAllTechnologiesQueryResponse> Handle(GetAllTechnologiesQueryRequest request, CancellationToken cancellationToken)
    {
        var query = _readRepository.GetAll(false);

        var totalCount = await query.CountAsync();
        var technologies = await query
            .Skip(request.Parameters.PageIndex * request.Parameters.PageSize)
            .Take(request.Parameters.PageSize)
            .ProjectTo<ViewTechnologyDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new GetAllTechnologiesQueryResponse
        {
            TotalCount = totalCount,
            Technologies = technologies
        };
    }
}
