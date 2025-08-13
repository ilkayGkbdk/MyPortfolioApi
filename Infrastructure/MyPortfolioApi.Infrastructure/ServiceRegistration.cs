using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyPortfolioApi.Infrastructure.Contexts;

namespace MyPortfolioApi.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<MyPortfolioApiDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
    }
}