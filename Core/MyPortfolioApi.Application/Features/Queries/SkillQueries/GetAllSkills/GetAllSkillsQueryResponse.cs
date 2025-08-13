using System;
using MyPortfolioApi.Application.DTOs.Skill;

namespace MyPortfolioApi.Application.Features.Queries.SkillQueries.GetAllSkills;

public class GetAllSkillsQueryResponse
{
    public int TotalCount { get; set; }
    public List<ViewSkillDto> Skills { get; set; }
}
