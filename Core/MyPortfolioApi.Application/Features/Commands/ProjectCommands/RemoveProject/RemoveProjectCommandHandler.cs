using System;
using System.Net;
using MediatR;
using MyPortfolioApi.Application.Exceptions;
using MyPortfolioApi.Application.Repositories.Project;

namespace MyPortfolioApi.Application.Features.Commands.ProjectCommands.RemoveProject;

public class RemoveProjectCommandHandler : IRequestHandler<RemoveProjectCommandRequest, RemoveProjectCommandResponse>
{
    private readonly IProjectReadRepository _readRepository;
    private readonly IProjectWriteRepository _writeRepostiroy;

    public RemoveProjectCommandHandler(IProjectReadRepository readRepository, IProjectWriteRepository writeRepostiroy)
    {
        _readRepository = readRepository;
        _writeRepostiroy = writeRepostiroy;
    }

    public async Task<RemoveProjectCommandResponse> Handle(RemoveProjectCommandRequest request, CancellationToken cancellationToken)
    {
        var existProject = await _readRepository.GetByIdAsync(request.Id, false) ?? throw new DataNotFoundException("Project", request.Id);

        await _writeRepostiroy.RemoveAsync(request.Id);
        await _writeRepostiroy.SaveChangesAsync();

        return new RemoveProjectCommandResponse
        {
            Status = HttpStatusCode.OK,
            Message = $"Project with id '{existProject.Id}' has removed successfully."
        };
    }
}
