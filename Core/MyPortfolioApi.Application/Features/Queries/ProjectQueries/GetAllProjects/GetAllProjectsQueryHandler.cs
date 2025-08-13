using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MyPortfolioApi.Application.DTOs.Project;
using MyPortfolioApi.Application.Repositories.Project;

namespace MyPortfolioApi.Application.Features.Queries.ProjectQueries.GetAllProjects;

public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQueryRequest, GetAllProjectsQueryResponse>
{
    private readonly IProjectReadRepository _repository;
    private readonly IMapper _mapper;

    public GetAllProjectsQueryHandler(IProjectReadRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetAllProjectsQueryResponse> Handle(GetAllProjectsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var totalCount = _repository.GetAll().Count();
        var projects = _repository.GetAll()
            .Skip(request.Parameters.PageIndex * request.Parameters.PageSize)
            .Take(request.Parameters.PageSize)
            .ProjectTo<ViewProjectDto>(_mapper.ConfigurationProvider)
            .ToList();

        return new GetAllProjectsQueryResponse { TotalCount = totalCount, Projects = projects };
    }
}