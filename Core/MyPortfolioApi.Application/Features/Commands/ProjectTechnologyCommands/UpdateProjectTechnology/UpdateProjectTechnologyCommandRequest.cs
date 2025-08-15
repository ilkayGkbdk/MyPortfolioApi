using System;
using MediatR;

namespace MyPortfolioApi.Application.Features.Commands.ProjectTechnologyCommands.UpdateProjectTechnology;

public class UpdateProjectTechnologyCommandRequest : IRequest<UpdateProjectTechnologyCommandResponse>
{
    public string Id { get; set; }
    public bool IsPrimary { get; set; }
}
