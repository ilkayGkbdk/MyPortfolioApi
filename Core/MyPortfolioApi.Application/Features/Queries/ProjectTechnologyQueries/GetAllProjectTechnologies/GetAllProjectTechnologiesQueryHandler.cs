using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolioApi.Application.DTOs.ProjectTechnology;
using MyPortfolioApi.Application.Repositories.ProjectTechnology;

namespace MyPortfolioApi.Application.Features.Queries.ProjectTechnologyQueries.GetAllProjectTechnologies;

public class GetAllProjectTechnologiesQueryHandler : IRequestHandler<GetAllProjectTechnologiesQueryRequest, GetAllProjectTechnologiesQueryResponse>
{
    private readonly IProjectTechnologyReadRepository _readRepository;
    private readonly IMapper _mapper;

    public GetAllProjectTechnologiesQueryHandler(IProjectTechnologyReadRepository readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<GetAllProjectTechnologiesQueryResponse> Handle(GetAllProjectTechnologiesQueryRequest request, CancellationToken cancellationToken)
    {
        var query = _readRepository.GetAll(false);

        var totalCount = await query.CountAsync();
        var projectTechnologies = await query
            .Skip(request.Parameters.PageIndex * request.Parameters.PageSize)
            .Take(request.Parameters.PageSize)
            .ProjectTo<ViewProjectTechnologyDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new GetAllProjectTechnologiesQueryResponse
        {
            TotalCount = totalCount,
            ProjectTechnologies = projectTechnologies
        };
    }
}
