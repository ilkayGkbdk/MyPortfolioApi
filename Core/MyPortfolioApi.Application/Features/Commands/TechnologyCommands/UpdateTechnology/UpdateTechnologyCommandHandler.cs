using System;
using System.Net;
using AutoMapper;
using MediatR;
using MyPortfolioApi.Application.Exceptions;
using MyPortfolioApi.Application.Repositories.Technology;

namespace MyPortfolioApi.Application.Features.Commands.TechnologyCommands.UpdateTechnology;

public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommandRequest, UpdateTechnologyCommandResponse>
{
    private readonly ITechnologyReadRepository _readRepository;
    private readonly ITechnologyWriteRepository _writeRepository;
    private readonly IMapper _mapper;

    public UpdateTechnologyCommandHandler(ITechnologyReadRepository readRepository, ITechnologyWriteRepository writeRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _mapper = mapper;
    }

    public async Task<UpdateTechnologyCommandResponse> Handle(UpdateTechnologyCommandRequest request, CancellationToken cancellationToken)
    {
        var existsTechnology = await _readRepository.GetByIdAsync(request.Id) ?? throw new DataNotFoundException("Technology", request.Id);

        var technologyDto = _mapper.Map(request, existsTechnology);
        _writeRepository.Update(technologyDto);
        await _writeRepository.SaveChangesAsync();

        return new UpdateTechnologyCommandResponse
        {
            Status = HttpStatusCode.OK,
            Message = $"Technology with id '{technologyDto.Id}' updated successfully."
        };
    }
}
