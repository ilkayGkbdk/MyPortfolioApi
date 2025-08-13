using System.ComponentModel.DataAnnotations.Schema;
using MyPortfolioApi.Domain.Entities.Common;

namespace MyPortfolioApi.Domain.Entities;

public class ProjectTechnology : BaseEntity
{
    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
    
    public Guid TechnologyId { get; set; }
    public Technology Technology { get; set; }

    public bool IsPrimary { get; set; }
}