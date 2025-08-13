using MyPortfolioApi.Application.Repositories.ProjectTechnology;
using MyPortfolioApi.Infrastructure.Contexts;

namespace MyPortfolioApi.Infrastructure.Repositories.ProjectTechnology;

public class ProjectTechnologyReadRepository : ReadRepository<Domain.Entities.ProjectTechnology>, IProjectTechnologyReadRepository
{
    public ProjectTechnologyReadRepository(MyPortfolioApiDbContext context) : base(context)
    {
    }
}