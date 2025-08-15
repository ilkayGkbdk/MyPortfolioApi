using System;
using MediatR;

namespace MyPortfolioApi.Application.Features.Commands.TechnologyCommands.CreateTechnology;

public class CreateTechnologyCommandRequest : IRequest<CreateTechnologyCommandResponse>
{
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
}
