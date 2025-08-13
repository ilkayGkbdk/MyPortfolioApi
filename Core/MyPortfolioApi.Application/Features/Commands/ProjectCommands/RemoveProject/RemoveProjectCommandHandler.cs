using System;
using MediatR;
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
        var existProject = await _readRepository.GetByIdAsync(request.Id, false);
        if (existProject == null)
        {
            return new RemoveProjectCommandResponse
            {
                Success = false,
                Message = $"Project with id '{request.Id}' has not exists."
            };
        }

        await _writeRepostiroy.RemoveAsync(request.Id);
        await _writeRepostiroy.SaveChangesAsync();

        return new RemoveProjectCommandResponse
        {
            Success = true,
            Message = $"Project with id '{existProject.Id}' has updated successfully."
        };
    }
}
