using System;
using MediatR;

namespace MyPortfolioApi.Application.Features.Queries.TechnologyQueries.GetTechnologyById;

public class GetTechnologyByIdQueryRequest : IRequest<GetTechnologyByIdQueryResponse>
{
    public string Id { get; set; }

    public GetTechnologyByIdQueryRequest(string id)
    {
        Id = id;
    }
}
