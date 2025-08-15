using System;
using MyPortfolioApi.Application.DTOs.Technology;

namespace MyPortfolioApi.Application.Features.Queries.TechnologyQueries.GetAllTechnologies;

public class GetAllTechnologiesQueryResponse
{
    public int TotalCount { get; set; }
    public List<ViewTechnologyDto> Technologies { get; set; }
}
