using MyPortfolioApi.Application.Repositories.Project;
using MyPortfolioApi.Infrastructure.Contexts;

namespace MyPortfolioApi.Infrastructure.Repositories.Project;

public class ProjectWriteRepository : WriteRepository<Domain.Entities.Project>, IProjectWriteRepository
{
    public ProjectWriteRepository(MyPortfolioApiDbContext context) : base(context)
    {
    }
}