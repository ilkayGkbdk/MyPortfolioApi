using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyPortfolioApi.Application.Repositories;
using MyPortfolioApi.Domain.Entities.Common;
using MyPortfolioApi.Infrastructure.Contexts;

namespace MyPortfolioApi.Infrastructure.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly MyPortfolioApiDbContext _context;

    public ReadRepository(MyPortfolioApiDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();
    
    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();
        return tracking ? query : query.AsNoTracking();
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.Where(method);
        return tracking ? query : query.AsNoTracking();
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking) query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(method);
    }

    public async Task<T> GetByIdAsync(string id, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking) query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
    }
}