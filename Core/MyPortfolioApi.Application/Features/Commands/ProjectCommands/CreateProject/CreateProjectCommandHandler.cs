using System;
using System.Net;
using AutoMapper;
using MediatR;
using MyPortfolioApi.Application.Exceptions;
using MyPortfolioApi.Application.Repositories.Project;
using MyPortfolioApi.Domain.Entities;
using MyPortfolioApi.Domain.Exceptions;

namespace MyPortfolioApi.Application.Features.Commands.ProjectCommands.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommandRequest, CreateProjectCommandResponse>
{
    private readonly IProjectWriteRepository _writeRepository;
    private readonly IProjectReadRepository _readRepository;
    private readonly IMapper _mapper;

    public CreateProjectCommandHandler(IProjectWriteRepository writeRepository, IProjectReadRepository readRepository, IMapper mapper)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<CreateProjectCommandResponse> Handle(CreateProjectCommandRequest request, CancellationToken cancellationToken)
    {
        var projectWithThumbnail = await _readRepository.GetSingleAsync(p => p.ThumbnailUrl == request.ThumbnailUrl, false) ?? throw new ProjectThumbnailAlreadyExists(request.ThumbnailUrl);

        var project = _mapper.Map<Project>(request);
        await _writeRepository.AddAsync(project);
        await _writeRepository.SaveChangesAsync();

        return new CreateProjectCommandResponse
        {
            Status = HttpStatusCode.OK,
            Message = $"Project with id '{project.Id}' has created successfully."
        };
    }
}
