using System;
using MyPortfolioApi.Application.DTOs.Common;

namespace MyPortfolioApi.Application.DTOs.Skill;

public class ViewSkillDto : BaseViewDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public byte Level { get; set; }
    public string Category { get; set; }
}
