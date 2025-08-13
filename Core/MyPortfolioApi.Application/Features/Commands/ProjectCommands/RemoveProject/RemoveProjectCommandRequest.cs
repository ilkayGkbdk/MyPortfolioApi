using System;
using MediatR;

namespace MyPortfolioApi.Application.Features.Commands.ProjectCommands.RemoveProject;

public class RemoveProjectCommandRequest : IRequest<RemoveProjectCommandResponse>
{
    public string Id { get; set; }

    public RemoveProjectCommandRequest(string id)
    {
        Id = id;
    }
}
