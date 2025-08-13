using MyPortfolioApi.Domain.Entities.Common;

namespace MyPortfolioApi.Domain.Entities;

public class Technology : BaseEntity
{
    public string Name { get; set; }
    public string Category { get; set; }
    
    public List<ProjectTechnology> ProjectTechnologies { get; set; }
}