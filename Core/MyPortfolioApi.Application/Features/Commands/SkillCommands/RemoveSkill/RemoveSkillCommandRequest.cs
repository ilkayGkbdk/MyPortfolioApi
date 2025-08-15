using System;
using MediatR;

namespace MyPortfolioApi.Application.Features.Commands.SkillCommands.RemoveSkill;

public class RemoveSkillCommandRequest : IRequest<RemoveSkillCommandResponse>
{
    public string Id { get; set; }

    public RemoveSkillCommandRequest(string id)
    {
        Id = id;
    }
}
