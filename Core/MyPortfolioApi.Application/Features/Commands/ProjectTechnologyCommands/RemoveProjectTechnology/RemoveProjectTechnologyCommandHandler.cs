using System;
using MediatR;
using MyPortfolioApi.Application.Exceptions;
using MyPortfolioApi.Application.Repositories.ProjectTechnology;

namespace MyPortfolioApi.Application.Features.Commands.ProjectTechnologyCommands.RemoveProjectTechnology;

public class RemoveProjectTechnologyCommandHandler : IRequestHandler<RemoveProjectTechnologyCommandRequest, RemoveProjectTechnologyCommandResponse>
{
    private readonly IProjectTechnologyReadRepository _readRepository;
    private readonly IProjectTechnologyWriteRepository _writeRepository;

    public RemoveProjectTechnologyCommandHandler(IProjectTechnologyReadRepository readRepository, IProjectTechnologyWriteRepository writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task<RemoveProjectTechnologyCommandResponse> Handle(RemoveProjectTechnologyCommandRequest request, CancellationToken cancellationToken)
    {
        var projectTech = await _readRepository.GetByIdAsync(request.Id, false) ?? throw new DataNotFoundException("Project Technology", request.Id);

        await _writeRepository.RemoveAsync(projectTech.Id.ToString());
        await _writeRepository.SaveChangesAsync();

        return new RemoveProjectTechnologyCommandResponse
        {
            Message = $"Project Technology with id '{request.Id}' has deleted successfully."
        };
    }
}
