using System;
using MyPortfolioApi.Application.DTOs.Common;

namespace MyPortfolioApi.Application.DTOs.Technology;

public class ViewTechnologyDto : BaseViewDto
{
    public string Name { get; set; }
    public string Category { get; set; }
}
