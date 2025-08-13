using MyPortfolioApi.Application.DTOs.Project;

namespace MyPortfolioApi.Application.Features.Queries.ProjectQueries.GetProjectById;

public class GetProjectByIdQueryResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public ViewProjectDto Project { get; set; }
}