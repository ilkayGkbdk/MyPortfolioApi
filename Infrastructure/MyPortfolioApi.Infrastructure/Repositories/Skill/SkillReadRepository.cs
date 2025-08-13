using MyPortfolioApi.Application.Repositories.Skill;
using MyPortfolioApi.Infrastructure.Contexts;

namespace MyPortfolioApi.Infrastructure.Repositories.Skill;

public class SkillReadRepository : ReadRepository<Domain.Entities.Skill>, ISkillReadRepository
{
    public SkillReadRepository(MyPortfolioApiDbContext context) : base(context)
    {
    }
}