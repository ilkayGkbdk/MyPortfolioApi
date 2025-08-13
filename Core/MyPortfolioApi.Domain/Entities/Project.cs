using MyPortfolioApi.Domain.Entities.Common;

namespace MyPortfolioApi.Domain.Entities;

public class Project : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ThumbnailUrl { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public List<ProjectTechnology> ProjectTechnologies { get; set; }
}