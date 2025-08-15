using System;
using MediatR;

namespace MyPortfolioApi.Application.Features.Commands.SkillCommands.CreateSkill;

public class CreateSkillCommandRequest : IRequest<CreateSkillCommandResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public byte Level { get; set; }
    public string Category { get; set; }
}
