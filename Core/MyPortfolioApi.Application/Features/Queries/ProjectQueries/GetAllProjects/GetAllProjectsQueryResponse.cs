using MyPortfolioApi.Application.DTOs.Project;

namespace MyPortfolioApi.Application.Features.Queries.ProjectQueries.GetAllProjects;

public class GetAllProjectsQueryResponse
{
    public int TotalCount { get; set; }
    public List<ViewProjectDto> Projects { get; set; }
}