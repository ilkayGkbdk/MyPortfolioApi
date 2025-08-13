using System;

namespace MyPortfolioApi.Application.Features.Commands.ProjectCommands.CreateProject;

public class CreateProjectCommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
}
