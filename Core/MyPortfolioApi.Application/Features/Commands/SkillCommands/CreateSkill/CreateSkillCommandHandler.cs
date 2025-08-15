using System;
using System.Net;
using AutoMapper;
using MediatR;
using MyPortfolioApi.Application.Repositories.Skill;
using MyPortfolioApi.Domain.Entities;

namespace MyPortfolioApi.Application.Features.Commands.SkillCommands.CreateSkill;

public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommandRequest, CreateSkillCommandResponse>
{
    private readonly ISkillWriteRepository _skillWriteRepository;
    private readonly IMapper _mapper;

    public CreateSkillCommandHandler(ISkillWriteRepository skillWriteRepository, IMapper mapper)
    {
        _skillWriteRepository = skillWriteRepository;
        _mapper = mapper;
    }

    public async Task<CreateSkillCommandResponse> Handle(CreateSkillCommandRequest request, CancellationToken cancellationToken)
    {
        var skill = _mapper.Map<Skill>(request);
        await _skillWriteRepository.AddAsync(skill);
        await _skillWriteRepository.SaveChangesAsync();

        return new CreateSkillCommandResponse
        {
            Status = HttpStatusCode.OK,
            Message = $"Skill with id {skill.Id} has been created successfully.",
        };
    }
}
