using AutoMapper;
using MyPortfolioApi.Application.DTOs.Project;
using MyPortfolioApi.Application.DTOs.ProjectTechnology;
using MyPortfolioApi.Application.DTOs.Skill;
using MyPortfolioApi.Application.DTOs.Technology;
using MyPortfolioApi.Application.Features.Commands.ProjectCommands.CreateProject;
using MyPortfolioApi.Application.Features.Commands.ProjectCommands.UpdateProject;
using MyPortfolioApi.Application.Features.Commands.ProjectTechnologyCommands.CreateProjectTechnology;
using MyPortfolioApi.Application.Features.Commands.SkillCommands.CreateSkill;
using MyPortfolioApi.Application.Features.Commands.SkillCommands.UpdateSkill;
using MyPortfolioApi.Application.Features.Commands.TechnologyCommands.CreateTechnology;
using MyPortfolioApi.Application.Features.Commands.TechnologyCommands.UpdateTechnology;
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
        CreateMap<CreateSkillCommandRequest, Skill>();
        CreateMap<UpdateSkillCommandRequest, Skill>();

        // Technology
        CreateMap<Technology, ViewTechnologyDto>();
        CreateMap<ViewTechnologyDto, Technology>();
        CreateMap<CreateTechnologyCommandRequest, Technology>();
        CreateMap<UpdateTechnologyCommandRequest, Technology>();

        // ProjectTechnology
        CreateMap<ProjectTechnology, ViewProjectTechnologyDto>();
        CreateMap<ViewProjectTechnologyDto, ProjectTechnology>();
        CreateMap<CreateProjectTechnologyCommandRequest, ProjectTechnology>();
    }
}