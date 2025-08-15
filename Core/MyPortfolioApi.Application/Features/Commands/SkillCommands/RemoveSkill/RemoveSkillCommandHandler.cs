using System;
using System.Net;
using MediatR;
using MyPortfolioApi.Application.Exceptions;
using MyPortfolioApi.Application.Repositories.Skill;

namespace MyPortfolioApi.Application.Features.Commands.SkillCommands.RemoveSkill;

public class RemoveSkillCommandHandler : IRequestHandler<RemoveSkillCommandRequest, RemoveSkillCommandResponse>
{
    private readonly ISkillReadRepository _readRepository;
    private readonly ISkillWriteRepository _writeRepository;

    public RemoveSkillCommandHandler(ISkillReadRepository readRepository, ISkillWriteRepository writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task<RemoveSkillCommandResponse> Handle(RemoveSkillCommandRequest request, CancellationToken cancellationToken)
    {
        var skill = await _readRepository.GetByIdAsync(request.Id, false) ?? throw new DataNotFoundException("Skill", request.Id);

        await _writeRepository.RemoveAsync(request.Id);
        await _writeRepository.SaveChangesAsync();

        return new RemoveSkillCommandResponse
        {
            Status = HttpStatusCode.OK,
            Message = $"Skill with id '{request.Id}' has been deleted successfully"
        };
    }
}
