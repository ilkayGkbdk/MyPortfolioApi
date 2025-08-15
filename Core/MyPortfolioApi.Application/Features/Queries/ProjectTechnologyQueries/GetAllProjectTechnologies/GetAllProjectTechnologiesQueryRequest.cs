using System;
using MediatR;
using MyPortfolioApi.Application.RequestParameters;

namespace MyPortfolioApi.Application.Features.Queries.ProjectTechnologyQueries.GetAllProjectTechnologies;

public class GetAllProjectTechnologiesQueryRequest : IRequest<GetAllProjectTechnologiesQueryResponse>
{
    public PaginationParameters Parameters { get; set; }

    public GetAllProjectTechnologiesQueryRequest(PaginationParameters parameters)
    {
        Parameters = parameters;
    }
}
