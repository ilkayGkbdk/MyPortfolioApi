using MyPortfolioApi.Application.Repositories.Technology;
using MyPortfolioApi.Infrastructure.Contexts;

namespace MyPortfolioApi.Infrastructure.Repositories.Technology;

public class TechnologyReadRepository : ReadRepository<Domain.Entities.Technology>, ITechnologyReadRepository
{
    public TechnologyReadRepository(MyPortfolioApiDbContext context) : base(context)
    {
    }
}