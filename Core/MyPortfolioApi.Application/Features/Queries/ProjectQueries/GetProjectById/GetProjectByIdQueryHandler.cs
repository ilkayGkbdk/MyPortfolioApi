using System.Net;
using AutoMapper;
using MediatR;
using MyPortfolioApi.Application.DTOs.Project;
using MyPortfolioApi.Application.Exceptions;
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
        var project = await _repository.GetByIdAsync(request.Id) ?? throw new DataNotFoundException("Project", request.Id);

        var projectDto = _mapper.Map<ViewProjectDto>(project);
        return new GetProjectByIdQueryResponse
        {
            Status = HttpStatusCode.OK,
            Project = projectDto
        };
    }
}