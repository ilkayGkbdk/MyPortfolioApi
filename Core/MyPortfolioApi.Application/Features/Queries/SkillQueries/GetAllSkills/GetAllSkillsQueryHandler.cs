using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyPortfolioApi.Application.DTOs.Skill;
using MyPortfolioApi.Application.Repositories.Skill;

namespace MyPortfolioApi.Application.Features.Queries.SkillQueries.GetAllSkills;

public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQueryRequest, GetAllSkillsQueryResponse>
{
    private readonly ISkillReadRepository _readRepository;
    private readonly IMapper _mapper;

    public GetAllSkillsQueryHandler(ISkillReadRepository readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<GetAllSkillsQueryResponse> Handle(GetAllSkillsQueryRequest request, CancellationToken cancellationToken)
    {
        var query = _readRepository.GetAll(false);

        var totalCount = await query.CountAsync();
        var skills = await query
            .Skip(request.Parameters.PageIndex * request.Parameters.PageSize)
            .Take(request.Parameters.PageSize)
            .ProjectTo<ViewSkillDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new GetAllSkillsQueryResponse
        {
            TotalCount = totalCount,
            Skills = skills
        };
    }
}
