using Microsoft.EntityFrameworkCore; // UseSqlite
using Microsoft.Extensions.DependencyInjection; // IServiceCollection

namespace Courses_Shared
{
    public static class ProgrammingCoursesContextExtensions
    {
        /// <summary>
        /// Adds NorthwindContext to the specified IServiceCollection. Uses the Sqlite database provider.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="relativePath">Set to override the default of ".."</param>
        /// <returns>An IServiceCollection that can be used to add more services.</returns>
        public static IServiceCollection AddCoursesContext(
          this IServiceCollection services, string relativePath = "..")
        {
            string databasePath = Path.Combine(relativePath, "Northwind.db");

            services.AddDbContext<ProgrammingCoursesContext>(options =>
              options.UseSqlite($"Data Source={databasePath}")
              .UseLoggerFactory(new ConsoleLoggerFactory())
            );

            return services;
        }
    }
}
