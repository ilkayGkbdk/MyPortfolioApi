using MyPortfolioApi.Application.DTOs.Common;
using MyPortfolioApi.Application.DTOs.Project;

namespace MyPortfolioApi.Application.Features.Queries.ProjectQueries.GetProjectById;

public class GetProjectByIdQueryResponse : BaseResponseDto
{
    public ViewProjectDto Project { get; set; }
}