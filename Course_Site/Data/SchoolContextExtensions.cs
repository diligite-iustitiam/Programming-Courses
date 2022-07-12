using Microsoft.EntityFrameworkCore; // UseSqlite
using Microsoft.Extensions.DependencyInjection; // IServiceCollection
namespace Course_Site.Data;
    public static class SchoolContextExtensions
{
    /// <summary>
    /// Adds NorthwindContext to the specified IServiceCollection. Uses the Sqlite database provider.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="relativePath">Set to override the default of ".."</param>
    /// <returns>An IServiceCollection that can be used to add more services.</returns>
    public static IServiceCollection AddSchoolContext(
      this IServiceCollection services, string relativePath = "..")
    {
        string databasePath = Path.Combine(relativePath, "SchoolContext.db");

        services.AddDbContext<SchoolContext>(options =>
          options.UseSqlite($"Data Source={databasePath}")
          .UseLoggerFactory(new ConsoleLoggerFactory())
        );

        return services;
    }
}


