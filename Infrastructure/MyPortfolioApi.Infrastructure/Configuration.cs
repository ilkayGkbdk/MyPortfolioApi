using Microsoft.Extensions.Configuration;

namespace MyPortfolioApi.Infrastructure;

public static class Configuration
{
    public static string? ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/MyPortfolioApi.WebApi"));
            configurationManager.AddJsonFile("appsettings.Development.json");
            
            return configurationManager.GetConnectionString("Postgre");
        }
    }
}