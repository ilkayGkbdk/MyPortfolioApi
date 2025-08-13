using System;
using MediatR;

namespace MyPortfolioApi.Application.Features.Queries.SkillQueries.GetSkillById;

public class GetSkillByIdQueryRequest : IRequest<GetSkillByIdQueryResponse>
{
    public string Id { get; set; }
}
