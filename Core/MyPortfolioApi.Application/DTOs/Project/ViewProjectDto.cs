using MyPortfolioApi.Application.DTOs.Common;

namespace MyPortfolioApi.Application.DTOs.Project;

public class ViewProjectDto : BaseViewDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ThumbnailUrl { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}