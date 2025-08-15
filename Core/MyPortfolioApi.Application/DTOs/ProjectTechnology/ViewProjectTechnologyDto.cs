using System;
using MyPortfolioApi.Application.DTOs.Common;

namespace MyPortfolioApi.Application.DTOs.ProjectTechnology;

public class ViewProjectTechnologyDto : BaseViewDto
{
    public Guid ProjectId { get; set; }
    public Guid TechnologyId { get; set; }
    public bool IsPrimary { get; set; }
}
