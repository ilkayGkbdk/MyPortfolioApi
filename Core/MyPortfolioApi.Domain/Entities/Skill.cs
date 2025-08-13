using MyPortfolioApi.Domain.Entities.Common;

namespace MyPortfolioApi.Domain.Entities;

public class Skill : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public byte Level { get; set; }
    public string Category { get; set; }
}