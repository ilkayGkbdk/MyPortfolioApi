using System;
using MediatR;

namespace MyPortfolioApi.Application.Features.Commands.SkillCommands.UpdateSkill;

public class UpdateSkillCommandRequest : IRequest<UpdateSkillCommandResponse>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public byte Level { get; set; }
    public string Category { get; set; }
}
