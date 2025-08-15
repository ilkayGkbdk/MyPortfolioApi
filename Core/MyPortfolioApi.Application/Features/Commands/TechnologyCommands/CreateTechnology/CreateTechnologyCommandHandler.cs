using System;
using System.Net;
using AutoMapper;
using MediatR;
using MyPortfolioApi.Application.Repositories.Technology;
using MyPortfolioApi.Domain.Entities;

namespace MyPortfolioApi.Application.Features.Commands.TechnologyCommands.CreateTechnology;

public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommandRequest, CreateTechnologyCommandResponse>
{
    private readonly ITechnologyWriteRepository _writeRepository;
    private readonly IMapper _mapper;

    public CreateTechnologyCommandHandler(ITechnologyWriteRepository writeRepository, IMapper mapper)
    {
        _writeRepository = writeRepository;
        _mapper = mapper;
    }

    public async Task<CreateTechnologyCommandResponse> Handle(CreateTechnologyCommandRequest request, CancellationToken cancellationToken)
    {
        var technology = _mapper.Map<Technology>(request);
        await _writeRepository.AddAsync(technology);
        await _writeRepository.SaveChangesAsync();

        return new CreateTechnologyCommandResponse
        {
            Status = HttpStatusCode.OK,
            Message = $"Technology with id '{technology.Id}' '{technology.Name}' created successfully."
        };
    }
}
