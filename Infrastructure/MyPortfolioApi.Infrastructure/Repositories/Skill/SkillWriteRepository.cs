using MyPortfolioApi.Application.Repositories.Skill;
using MyPortfolioApi.Infrastructure.Contexts;

namespace MyPortfolioApi.Infrastructure.Repositories.Skill;

public class SkillWriteRepository : WriteRepository<Domain.Entities.Skill>, ISkillWriteRepository
{
    public SkillWriteRepository(MyPortfolioApiDbContext context) : base(context)
    {
    }
}