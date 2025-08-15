using System;
using MyPortfolioApi.Application.DTOs.Common;
using MyPortfolioApi.Application.DTOs.Technology;

namespace MyPortfolioApi.Application.Features.Queries.TechnologyQueries.GetTechnologyById;

public class GetTechnologyByIdQueryResponse : BaseResponseDto
{
    public ViewTechnologyDto Technology { get; set; }
}
