
namespace MyPortfolioApi.Domain.Entities.Common;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual DateTime UpdatedAt { get; set; }
}