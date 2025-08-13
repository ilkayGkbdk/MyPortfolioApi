namespace MyPortfolioApi.Application.DTOs.Common;

public class BaseViewDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}