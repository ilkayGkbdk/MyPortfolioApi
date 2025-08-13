using MediatR;
using MyPortfolioApi.Application.RequestParameters;

namespace MyPortfolioApi.Application.Features.Queries.ProjectQueries.GetAllProjects;

public class GetAllProjectsQueryRequest : IRequest<GetAllProjectsQueryResponse>
{
    public PaginationParameters Parameters { get; set; }
}