using System;
using AutoMapper;
using MediatR;
using MyPortfolioApi.Application.Repositories.Project;
using MyPortfolioApi.Domain.Entities;

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
        var projectWithThumbnail = await _readRepository.GetSingleAsync(p => p.ThumbnailUrl == request.ThumbnailUrl, false);

        if (projectWithThumbnail != null)
        {
            return new CreateProjectCommandResponse
            {
                Success = false,
                Message = $"Project with thumbnail url '{request.ThumbnailUrl}' has already exists."
            };
        }

        var project = _mapper.Map<Project>(request);
        await _writeRepository.AddAsync(project);
        await _writeRepository.SaveChangesAsync();

        return new CreateProjectCommandResponse
        {
            Success = true,
            Message = $"Project with id '{project.Id}' has created successfully."
        };
    }
}
