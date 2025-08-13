using Microsoft.EntityFrameworkCore;
using MyPortfolioApi.Domain.Entities.Common;

namespace MyPortfolioApi.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}