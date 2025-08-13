using MediatR;

namespace MyPortfolioApi.Application.Features.Queries.ProjectQueries.GetProjectById;

public class GetProjectByIdQueryRequest : IRequest<GetProjectByIdQueryResponse>
{
    public string Id { get; set; }

    public GetProjectByIdQueryRequest(string id)
    {
        Id = id;
    }
}