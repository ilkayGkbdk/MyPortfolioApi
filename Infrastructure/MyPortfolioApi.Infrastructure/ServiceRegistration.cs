using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyPortfolioApi.Application.Repositories.Project;
using MyPortfolioApi.Application.Repositories.ProjectTechnology;
using MyPortfolioApi.Application.Repositories.Skill;
using MyPortfolioApi.Application.Repositories.Technology;
using MyPortfolioApi.Infrastructure.Contexts;
using MyPortfolioApi.Infrastructure.Repositories.Project;
using MyPortfolioApi.Infrastructure.Repositories.ProjectTechnology;
using MyPortfolioApi.Infrastructure.Repositories.Skill;
using MyPortfolioApi.Infrastructure.Repositories.Technology;

namespace MyPortfolioApi.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<MyPortfolioApiDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

        services.AddScoped<IProjectReadRepository, ProjectReadRepository>();
        services.AddScoped<IProjectWriteRepository, ProjectWriteRepository>();
        services.AddScoped<IProjectTechnologyReadRepository, ProjectTechnologyReadRepository>();
        services.AddScoped<IProjectTechnologyWriteRepository, ProjectTechnologyWriteRepository>();
        services.AddScoped<ISkillReadRepository, SkillReadRepository>();
        services.AddScoped<ISkillWriteRepository, SkillWriteRepository>();
        services.AddScoped<ITechnologyReadRepository, TechnologyReadRepository>();
        services.AddScoped<ITechnologyWriteRepository, TechnologyWriteRepository>();
    }
}