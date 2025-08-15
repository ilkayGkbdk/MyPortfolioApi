using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolioApi.Application.DTOs.Project;
using MyPortfolioApi.Application.Repositories.Project;

namespace MyPortfolioApi.Application.Features.Queries.ProjectQueries.GetAllProjects;

public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQueryRequest, GetAllProjectsQueryResponse>
{
    private readonly IProjectReadRepository _readRepository;
    private readonly IMapper _mapper;

    public GetAllProjectsQueryHandler(IProjectReadRepository readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<GetAllProjectsQueryResponse> Handle(GetAllProjectsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var query = _readRepository.GetAll(false);

        var totalCount = await query.CountAsync();
        var projects = await query
            .Skip(request.Parameters.PageIndex * request.Parameters.PageSize)
            .Take(request.Parameters.PageSize)
            .ProjectTo<ViewProjectDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new GetAllProjectsQueryResponse { TotalCount = totalCount, Projects = projects };
    }
}