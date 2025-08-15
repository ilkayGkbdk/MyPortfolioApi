using System;
using System.Net;
using AutoMapper;
using MediatR;
using MyPortfolioApi.Application.DTOs.Skill;
using MyPortfolioApi.Application.Exceptions;
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
        var skill = await _readRepository.GetByIdAsync(request.Id) ?? throw new DataNotFoundException("Skill", request.Id);

        var skillDto = _mapper.Map<ViewSkillDto>(skill);
        return new GetSkillByIdQueryResponse
        {
            Status = HttpStatusCode.OK,
            Skill = skillDto
        };
    }
}
