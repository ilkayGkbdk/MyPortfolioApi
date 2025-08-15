using System;
using MyPortfolioApi.Application.DTOs.ProjectTechnology;

namespace MyPortfolioApi.Application.Features.Queries.ProjectTechnologyQueries.GetAllProjectTechnologies;

public class GetAllProjectTechnologiesQueryResponse
{
    public int TotalCount { get; set; }
    public List<ViewProjectTechnologyDto> ProjectTechnologies { get; set; }
}
