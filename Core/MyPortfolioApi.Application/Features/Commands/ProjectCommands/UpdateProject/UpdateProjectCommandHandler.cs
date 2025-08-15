using System;
using System.Net;
using AutoMapper;
using MediatR;
using MyPortfolioApi.Application.Exceptions;
using MyPortfolioApi.Application.Repositories.Project;

namespace MyPortfolioApi.Application.Features.Commands.ProjectCommands.UpdateProject;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommandRequest, UpdateProjectCommandResponse>
{
    private readonly IProjectReadRepository _readRepository;
    private readonly IProjectWriteRepository _writeRepository;
    private readonly IMapper _mapper;

    public UpdateProjectCommandHandler(IProjectReadRepository readRepository, IProjectWriteRepository writeRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _mapper = mapper;
    }

    public async Task<UpdateProjectCommandResponse> Handle(UpdateProjectCommandRequest request, CancellationToken cancellationToken)
    {
        var existProject = await _readRepository.GetByIdAsync(request.Id, false) ?? throw new DataNotFoundException("Project", request.Id);

        var updatedProject = _mapper.Map(request, existProject);
        _writeRepository.Update(updatedProject);
        await _writeRepository.SaveChangesAsync();

        return new UpdateProjectCommandResponse
        {
            Status = HttpStatusCode.OK,
            Message = $"Project with id '{updatedProject.Id}' updated successfuly."
        };
    }
}
