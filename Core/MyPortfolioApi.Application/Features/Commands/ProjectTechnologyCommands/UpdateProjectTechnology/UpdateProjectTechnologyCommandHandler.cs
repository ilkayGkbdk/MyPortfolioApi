using System;
using AutoMapper;
using MediatR;
using MyPortfolioApi.Application.Exceptions;
using MyPortfolioApi.Application.Repositories.Project;
using MyPortfolioApi.Application.Repositories.ProjectTechnology;

namespace MyPortfolioApi.Application.Features.Commands.ProjectTechnologyCommands.UpdateProjectTechnology;

public class UpdateProjectTechnologyCommandHandler : IRequestHandler<UpdateProjectTechnologyCommandRequest, UpdateProjectTechnologyCommandResponse>
{
    private readonly IProjectTechnologyReadRepository _readRepository;
    private readonly IProjectTechnologyWriteRepository _writeRepository;
    private readonly IMapper _mapper;

    public UpdateProjectTechnologyCommandHandler(IProjectTechnologyReadRepository readRepository, IProjectTechnologyWriteRepository writeRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _mapper = mapper;
    }

    public async Task<UpdateProjectTechnologyCommandResponse> Handle(UpdateProjectTechnologyCommandRequest request, CancellationToken cancellationToken)
    {
        var existsProjectTech = await _readRepository.GetByIdAsync(request.Id, false) ?? throw new DataNotFoundException("Project Technology", request.Id);

        var projectTechDto = _mapper.Map(request, existsProjectTech);
        _writeRepository.Update(projectTechDto);
        await _writeRepository.SaveChangesAsync();

        return new UpdateProjectTechnologyCommandResponse
        {
            Message = $"Project Technology with id '{projectTechDto.Id}' has updated successfully."
        };
    }
}
