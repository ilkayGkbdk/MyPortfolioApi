using System;
using MediatR;

namespace MyPortfolioApi.Application.Features.Commands.TechnologyCommands.UpdateTechnology;

public class UpdateTechnologyCommandRequest : IRequest<UpdateTechnologyCommandResponse>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
}
