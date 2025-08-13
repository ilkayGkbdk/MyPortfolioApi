using Microsoft.EntityFrameworkCore;
using MyPortfolioApi.Domain.Entities;

namespace MyPortfolioApi.Infrastructure.Contexts;

public class MyPortfolioApiDbContext : DbContext
{
    DbSet<Project> Projects { get; set; }
    DbSet<Technology> Technologies { get; set; }
    DbSet<ProjectTechnology> ProjectTechnologies { get; set; }
    DbSet<Skill> Skills { get; set; }

    public MyPortfolioApiDbContext(DbContextOptions options) : base(options) { }
}