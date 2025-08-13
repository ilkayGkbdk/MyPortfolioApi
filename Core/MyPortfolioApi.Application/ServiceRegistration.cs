using Microsoft.Extensions.DependencyInjection;
using MyPortfolioApi.Application.Mapping;

namespace MyPortfolioApi.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
        services.AddAutoMapper(expression => expression.AddProfile(new GeneralMapping()));
    }
}