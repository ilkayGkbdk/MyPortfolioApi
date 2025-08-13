using System;
using AutoMapper;
using MediatR;
using MyPortfolioApi.Application.DTOs.Skill;
using MyPortfolioApi.Application.Repositories.Skill;

namespace MyPortfolioApi.Application.Features.Queries.SkillQueries.GetSkillById;

public class GetSkillByIdQueryHandler : IRequestHandler<GetSkillByIdQueryRequest, GetSkillByIdQueryResponse>
{
    private readonly ISkillReadRepository _readRepository;
    private readonly IMapper _mapper;

    public GetSkillByIdQueryHandler(ISkillReadRepository readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<GetSkillByIdQueryResponse> Handle(GetSkillByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var skill = await _readRepository.GetByIdAsync(request.Id);
        if (skill == null)
        {
            return new GetSkillByIdQueryResponse
            {
                Success = false,
                Message = $"Skill with id '{request.Id}' has not exists.",
                Skill = null
            };
        }

        var skillDto = _mapper.Map<ViewSkillDto>(request);
        return new GetSkillByIdQueryResponse
        {
            Success = true,
            Skill = skillDto
        };
    }
}
