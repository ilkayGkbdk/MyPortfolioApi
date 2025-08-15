using System.Net;
using AutoMapper;
using MediatR;
using MyPortfolioApi.Application.DTOs.ProjectTechnology;
using MyPortfolioApi.Application.Exceptions;
using MyPortfolioApi.Application.Repositories.ProjectTechnology;

namespace MyPortfolioApi.Application.Features.Queries.ProjectTechnologyQueries.GetProjectTechnologyById;

public class GetProjectTechnologyByIdQueryHandler : IRequestHandler<GetProjectTechnologyByIdQueryRequest, GetProjectTechnologyByIdQueryResponse>
{
    private readonly IProjectTechnologyReadRepository _readRepository;
    private readonly IMapper _mapper;

    public GetProjectTechnologyByIdQueryHandler(IProjectTechnologyReadRepository readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<GetProjectTechnologyByIdQueryResponse> Handle(GetProjectTechnologyByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var projectTechnology = await _readRepository.GetByIdAsync(request.Id) ?? throw new DataNotFoundException("ProjectTechnology", request.Id);

        var projectTechDto = _mapper.Map<ViewProjectTechnologyDto>(projectTechnology);
        return new GetProjectTechnologyByIdQueryResponse
        {
            Status = HttpStatusCode.OK,
            ProjectTechnology = projectTechDto
        };
    }
}
