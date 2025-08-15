using System;
using MediatR;

namespace MyPortfolioApi.Application.Features.Commands.ProjectTechnologyCommands.RemoveProjectTechnology;

public class RemoveProjectTechnologyCommandRequest : IRequest<RemoveProjectTechnologyCommandResponse>
{
    public string Id { get; set; }

    public RemoveProjectTechnologyCommandRequest(string id)
    {
        Id = id;
    }
}
