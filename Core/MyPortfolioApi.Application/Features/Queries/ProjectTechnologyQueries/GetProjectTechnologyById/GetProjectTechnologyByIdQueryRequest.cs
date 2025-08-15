using System;
using MediatR;

namespace MyPortfolioApi.Application.Features.Queries.ProjectTechnologyQueries.GetProjectTechnologyById;

public class GetProjectTechnologyByIdQueryRequest : IRequest<GetProjectTechnologyByIdQueryResponse>
{
    public string Id { get; set; }

    public GetProjectTechnologyByIdQueryRequest(string id)
    {
        Id = id;
    }
}
