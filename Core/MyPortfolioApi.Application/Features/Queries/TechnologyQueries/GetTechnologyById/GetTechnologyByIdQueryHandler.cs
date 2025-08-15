using System;
using System.Net;
using AutoMapper;
using MediatR;
using MyPortfolioApi.Application.DTOs.Technology;
using MyPortfolioApi.Application.Exceptions;
using MyPortfolioApi.Application.Repositories.Technology;

namespace MyPortfolioApi.Application.Features.Queries.TechnologyQueries.GetTechnologyById;

public class GetTechnologyByIdQueryHandler : IRequestHandler<GetTechnologyByIdQueryRequest, GetTechnologyByIdQueryResponse>
{
    private readonly ITechnologyReadRepository _readRepository;
    private readonly IMapper _mapper;

    public GetTechnologyByIdQueryHandler(ITechnologyReadRepository readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<GetTechnologyByIdQueryResponse> Handle(GetTechnologyByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var existsTechnology = await _readRepository.GetByIdAsync(request.Id, false) ?? throw new DataNotFoundException("Technology", request.Id);

        var technologyDto = _mapper.Map<ViewTechnologyDto>(existsTechnology);
        return new GetTechnologyByIdQueryResponse
        {
            Status = HttpStatusCode.OK,
            Technology = technologyDto
        };
    }
}
