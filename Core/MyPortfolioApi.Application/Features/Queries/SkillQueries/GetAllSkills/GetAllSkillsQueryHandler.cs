using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MyPortfolioApi.Application.DTOs.Skill;
using MyPortfolioApi.Application.Repositories.Skill;

namespace MyPortfolioApi.Application.Features.Queries.SkillQueries.GetAllSkills;

public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQueryRequest, GetAllSkillsQueryResponse>
{
    private readonly ISkillReadRepository _repository;
    private readonly IMapper _mapper;

    public GetAllSkillsQueryHandler(ISkillReadRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetAllSkillsQueryResponse> Handle(GetAllSkillsQueryRequest request, CancellationToken cancellationToken)
    {
        var totalCount = _repository.GetAll().Count();
        var skills = _repository.GetAll()
            .Skip(request.Parameters.PageIndex * request.Parameters.PageSize)
            .Take(request.Parameters.PageSize)
            .ProjectTo<ViewSkillDto>(_mapper.ConfigurationProvider)
            .ToList();

        return new GetAllSkillsQueryResponse
        {
            TotalCount = totalCount,
            Skills = skills
        };
    }
}
