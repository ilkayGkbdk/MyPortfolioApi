using System;
using MediatR;
using MyPortfolioApi.Application.RequestParameters;

namespace MyPortfolioApi.Application.Features.Queries.TechnologyQueries.GetAllTechnologies;

public class GetAllTechnologiesQueryRequest : IRequest<GetAllTechnologiesQueryResponse>
{
    public PaginationParameters Parameters { get; set; }

    public GetAllTechnologiesQueryRequest(PaginationParameters parameters)
    {
        Parameters = parameters;
    }
}
