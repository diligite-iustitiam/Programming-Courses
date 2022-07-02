using Microsoft.EntityFrameworkCore; // UseSqlite
using Microsoft.Extensions.DependencyInjection; // IServiceCollection
using Course.Shared;
namespace Course_Site.Data
{
    
    
        public static class CourseContextExtensions
        {
            /// <summary>
            /// Adds NorthwindContext to the specified IServiceCollection. Uses the Sqlite database provider.
            /// </summary>
            /// <param name="services"></param>
            /// <param name="relativePath">Set to override the default of ".."</param>
            /// <returns>An IServiceCollection that can be used to add more services.</returns>
            public static IServiceCollection AddAcademyContext(
              this IServiceCollection services, string relativePath = "..")
            {
                string databasePath = Path.Combine(relativePath, "Academy.db");

                services.AddDbContext<Academy>(options =>
                  options.UseSqlite($"Data Source={databasePath}")
                  .UseLoggerFactory(new ConsoleLoggerFactory())
                );

                return services;
            }
        }

    }


