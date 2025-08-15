using System;
using System.Net;
using MediatR;
using MyPortfolioApi.Application.Exceptions;
using MyPortfolioApi.Application.Repositories.Technology;

namespace MyPortfolioApi.Application.Features.Commands.TechnologyCommands.RemoveTechnology;

public class RemoveTechnologyCommandHandler : IRequestHandler<RemoveTechnologyCommandRequest, RemoveTechnologyCommandResponse>
{
    private readonly ITechnologyReadRepository _readRepository;
    private readonly ITechnologyWriteRepository _writeRepository;

    public RemoveTechnologyCommandHandler(ITechnologyReadRepository readRepository, ITechnologyWriteRepository writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task<RemoveTechnologyCommandResponse> Handle(RemoveTechnologyCommandRequest request, CancellationToken cancellationToken)
    {
        var existsTechnology = await _readRepository.GetByIdAsync(request.Id, false) ?? throw new DataNotFoundException("Technology", request.Id);

        await _writeRepository.RemoveAsync(request.Id);
        await _writeRepository.SaveChangesAsync();

        return new RemoveTechnologyCommandResponse
        {
            Status = HttpStatusCode.OK,
            Message = $"Technology with id '{request.Id}' removed successfully."
        };
    }
}
