using MyPortfolioApi.Application.Repositories.ProjectTechnology;
using MyPortfolioApi.Infrastructure.Contexts;

namespace MyPortfolioApi.Infrastructure.Repositories.ProjectTechnology;

public class ProjectTechnologyWriteRepository : WriteRepository<Domain.Entities.ProjectTechnology>, IProjectTechnologyWriteRepository
{
    public ProjectTechnologyWriteRepository(MyPortfolioApiDbContext context) : base(context)
    {
    }
}