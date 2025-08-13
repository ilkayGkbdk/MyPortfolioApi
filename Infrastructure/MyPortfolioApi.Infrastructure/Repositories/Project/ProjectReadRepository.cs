using MyPortfolioApi.Application.Repositories;
using MyPortfolioApi.Application.Repositories.Project;
using MyPortfolioApi.Infrastructure.Contexts;

namespace MyPortfolioApi.Infrastructure.Repositories.Project;

public class ProjectReadRepository : ReadRepository<Domain.Entities.Project>, IProjectReadRepository
{
    public ProjectReadRepository(MyPortfolioApiDbContext context) : base(context)
    {
    }
}