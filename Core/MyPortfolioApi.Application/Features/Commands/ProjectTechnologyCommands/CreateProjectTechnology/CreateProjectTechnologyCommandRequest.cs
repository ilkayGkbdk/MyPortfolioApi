using System;
using MediatR;

namespace MyPortfolioApi.Application.Features.Commands.ProjectTechnologyCommands.CreateProjectTechnology;

public class CreateProjectTechnologyCommandRequest : IRequest<CreateProjectTechnologyCommandResponse>
{
    public Guid ProjectId { get; set; }
    public Guid TechnologyId { get; set; }
    public bool IsPrimary { get; set; }
}
