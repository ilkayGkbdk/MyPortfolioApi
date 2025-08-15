using System;
using System.Net;
using AutoMapper;
using MediatR;
using MyPortfolioApi.Application.Exceptions;
using MyPortfolioApi.Application.Repositories.Skill;

namespace MyPortfolioApi.Application.Features.Commands.SkillCommands.UpdateSkill;

public class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommandRequest, UpdateSkillCommandResponse>
{
    private readonly ISkillWriteRepository _skillWriteRepository;
    private readonly ISkillReadRepository _skillReadRepository;
    private readonly IMapper _mapper;

    public UpdateSkillCommandHandler(ISkillWriteRepository skillWriteRepository, ISkillReadRepository skillReadRepository, IMapper mapper)
    {
        _skillWriteRepository = skillWriteRepository;
        _skillReadRepository = skillReadRepository;
        _mapper = mapper;
    }

    public async Task<UpdateSkillCommandResponse> Handle(UpdateSkillCommandRequest request, CancellationToken cancellationToken)
    {
        var skill = await _skillReadRepository.GetByIdAsync(request.Id, false) ?? throw new DataNotFoundException("Skill", request.Id);

        var updatedSkill = _mapper.Map(request, skill);
        _skillWriteRepository.Update(updatedSkill);
        await _skillWriteRepository.SaveChangesAsync();

        return new UpdateSkillCommandResponse
        {
            Status = HttpStatusCode.OK,
            Message = $"Skill with id {updatedSkill.Id} updated successfully."
        };
    }
}
