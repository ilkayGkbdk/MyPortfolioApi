using System;
using MyPortfolioApi.Application.DTOs.Common;
using MyPortfolioApi.Application.DTOs.Skill;

namespace MyPortfolioApi.Application.Features.Queries.SkillQueries.GetSkillById;

public class GetSkillByIdQueryResponse : BaseResponseDto
{
    public ViewSkillDto Skill { get; set; }
}
