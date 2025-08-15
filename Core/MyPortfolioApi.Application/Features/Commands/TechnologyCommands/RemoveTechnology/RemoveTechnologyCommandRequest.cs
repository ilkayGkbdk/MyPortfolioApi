using System;
using MediatR;

namespace MyPortfolioApi.Application.Features.Commands.TechnologyCommands.RemoveTechnology;

public class RemoveTechnologyCommandRequest : IRequest<RemoveTechnologyCommandResponse>
{
    public string Id { get; set; }

    public RemoveTechnologyCommandRequest(string id)
    {
        Id = id;
    }
}
