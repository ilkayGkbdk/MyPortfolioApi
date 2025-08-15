using System;
using MyPortfolioApi.Application.DTOs.Common;
using MyPortfolioApi.Application.DTOs.ProjectTechnology;

namespace MyPortfolioApi.Application.Features.Queries.ProjectTechnologyQueries.GetProjectTechnologyById;

public class GetProjectTechnologyByIdQueryResponse : BaseResponseDto
{
    public ViewProjectTechnologyDto ProjectTechnology { get; set; }
}
