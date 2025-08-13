using AutoMapper;
using MyPortfolioApi.Application.DTOs.Project;
using MyPortfolioApi.Application.DTOs.Skill;
using MyPortfolioApi.Application.Features.Commands.ProjectCommands.CreateProject;
using MyPortfolioApi.Application.Features.Commands.ProjectCommands.UpdateProject;
using MyPortfolioApi.Domain.Entities;

namespace MyPortfolioApi.Application.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        // Project
        CreateMap<Project, ViewProjectDto>(); // all
        CreateMap<ViewProjectDto, Project>(); // by id
        CreateMap<CreateProjectCommandRequest, Project>();
        CreateMap<UpdateProjectCommandRequest, Project>();

        // Skill
        CreateMap<Skill, ViewSkillDto>();
        CreateMap<ViewSkillDto, Skill>();
    }
}