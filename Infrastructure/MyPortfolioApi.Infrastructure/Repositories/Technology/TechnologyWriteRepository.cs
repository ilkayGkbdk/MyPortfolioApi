using MyPortfolioApi.Application.Repositories.Technology;
using MyPortfolioApi.Infrastructure.Contexts;

namespace MyPortfolioApi.Infrastructure.Repositories.Technology;

public class TechnologyWriteRepository : WriteRepository<Domain.Entities.Technology>, ITechnologyWriteRepository
{
    public TechnologyWriteRepository(MyPortfolioApiDbContext context) : base(context)
    {
    }
}