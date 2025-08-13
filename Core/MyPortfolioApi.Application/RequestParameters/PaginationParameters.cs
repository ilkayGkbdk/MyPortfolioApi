namespace MyPortfolioApi.Application.RequestParameters;

public class PaginationParameters
{
    public int PageIndex { get; set; } = 0;
    public int PageSize { get; set; } = 5;
}