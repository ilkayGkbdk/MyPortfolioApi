using System;
using System.Net;
using AutoMapper;
using MediatR;
using MyPortfolioApi.Application.Exceptions;
using MyPortfolioApi.Application.Repositories.Project;
using MyPortfolioApi.Application.Repositories.ProjectTechnology;
using MyPortfolioApi.Application.Repositories.Technology;
using MyPortfolioApi.Domain.Entities;
using MyPortfolioApi.Domain.Exceptions;

namespace MyPortfolioApi.Application.Features.Commands.ProjectTechnologyCommands.CreateProjectTechnology;

public class CreateProjectTechnologyCommandHandler : IRequestHandler<CreateProjectTechnologyCommandRequest, CreateProjectTechnologyCommandResponse>
{
    private readonly IProjectTechnologyWriteRepository _writeRepository;
    private readonly IProjectTechnologyReadRepository _readRepository;
    private readonly IMapper _mapper;
    private readonly IProjectReadRepository _projectReadRepository;
    private readonly ITechnologyReadRepository _technologyReadRepository;

    public CreateProjectTechnologyCommandHandler(IProjectTechnologyWriteRepository writeRepository, IMapper mapper, IProjectTechnologyReadRepository readRepository, IProjectReadRepository projectReadRepository, ITechnologyReadRepository technologyReadRepository)
    {
        _writeRepository = writeRepository;
        _mapper = mapper;
        _readRepository = readRepository;
        _projectReadRepository = projectReadRepository;
        _technologyReadRepository = technologyReadRepository;
    }

    public async Task<CreateProjectTechnologyCommandResponse> Handle(CreateProjectTechnologyCommandRequest request, CancellationToken cancellationToken)
    {
        var existsProject = await _projectReadRepository.GetByIdAsync(request.ProjectId.ToString(), false) ?? throw new DataNotFoundException("Project", request.ProjectId);

        var existsTechnology = await _technologyReadRepository.GetByIdAsync(request.TechnologyId.ToString(), false) ?? throw new DataNotFoundException("Technology", request.TechnologyId);

        var existsProjectTechnology = await _readRepository.GetSingleAsync(
            p => p.ProjectId == request.ProjectId && p.TechnologyId == request.TechnologyId);

        if (existsProjectTechnology != null)
            throw new ProjectTechnologyAlreadyExistsException(request.ProjectId.ToString(), request.TechnologyId.ToString());

        var projectTechnology = _mapper.Map<ProjectTechnology>(request);
        await _writeRepository.AddAsync(projectTechnology);
        await _writeRepository.SaveChangesAsync();

        return new CreateProjectTechnologyCommandResponse
        {
            Status = HttpStatusCode.OK,
            Message = "Project technology created successfully."
        };
    }
}
