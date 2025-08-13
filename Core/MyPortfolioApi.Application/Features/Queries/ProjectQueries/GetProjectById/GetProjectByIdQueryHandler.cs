using AutoMapper;
using MediatR;
using MyPortfolioApi.Application.DTOs.Project;
using MyPortfolioApi.Application.Repositories.Project;

namespace MyPortfolioApi.Application.Features.Queries.ProjectQueries.GetProjectById;

public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQueryRequest, GetProjectByIdQueryResponse>
{
    private readonly IProjectReadRepository _repository;
    private readonly IMapper _mapper;

    public GetProjectByIdQueryHandler(IProjectReadRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetProjectByIdQueryResponse> Handle(GetProjectByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetByIdAsync(request.Id);
        if (project == null)
        {
            return new GetProjectByIdQueryResponse
            {
                Success = false,
                Message = $"Project with id '{request.Id}' does not exist.'",
                Project = null
            };
        }
        
        var businessDto = _mapper.Map<ViewProjectDto>(project);
        return new GetProjectByIdQueryResponse
        {
            Success = true,
            Project = businessDto
        };
    }
}