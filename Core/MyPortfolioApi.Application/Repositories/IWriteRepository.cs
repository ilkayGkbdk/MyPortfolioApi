using MyPortfolioApi.Domain.Entities.Common;

namespace MyPortfolioApi.Application.Repositories;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<bool> AddAsync(T data);
    Task<bool> AddRangeAsync(List<T> datas);
    bool Remove(T data);
    bool RemoveRange(List<T> datas);
    Task<bool> RemoveAsync(string id);
    bool Update(T data);
    Task<int> SaveChangesAsync();
}