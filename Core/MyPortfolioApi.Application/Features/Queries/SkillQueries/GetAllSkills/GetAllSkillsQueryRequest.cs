using System;
using MediatR;
using MyPortfolioApi.Application.RequestParameters;

namespace MyPortfolioApi.Application.Features.Queries.SkillQueries.GetAllSkills;

public class GetAllSkillsQueryRequest : IRequest<GetAllSkillsQueryResponse>
{
    public PaginationParameters Parameters { get; set; }
}
