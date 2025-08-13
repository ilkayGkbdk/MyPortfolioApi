using System;
using MediatR;

namespace MyPortfolioApi.Application.Features.Commands.ProjectCommands.UpdateProject;

public class UpdateProjectCommandRequest : IRequest<UpdateProjectCommandResponse>
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ThumbnailUrl { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
