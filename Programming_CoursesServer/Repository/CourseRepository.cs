using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Course.Shared;
using System.Collections.Concurrent;
using System.Linq;
namespace Programming_CoursesServer.Repository
{
    public class CourseRepository : ICoursesRepository
    {
        
            private static ConcurrentDictionary
        <int, ProgrammingCourse>? courseCache;

            // use an instance data context field because it should not be
            // cached due to their internal caching
            private Programming_CoursesContext db;

            public CourseRepository(Programming_CoursesContext injectedContext)
        { 
                db = injectedContext;



                // pre-load customers from database as a normal
                // Dictionary with CustomerId as the key,
                // then convert to a thread-safe ConcurentDictionary
                if (courseCache is null)
                {
                courseCache = new ConcurrentDictionary<int, ProgrammingCourse>(
                db.ProgrammingCourses.ToDictionary(c=>c.CourseId));
                }
            }
            public async Task<ProgrammingCourse?> CreateAsync(ProgrammingCourse p)
            {
            // normalize CustomerId into uppercase
            p.CourseId = p.CourseId;

                // add to database using EF Core
                EntityEntry<ProgrammingCourse> ad = await db.ProgrammingCourses.AddAsync(p);
                int aff = await db.SaveChangesAsync();
                if (aff == 1)
                {
                if (courseCache is null) return p;
                    // if the customer is new, add it to cache, else
                    // call UpdateCache method
                    return courseCache.AddOrUpdate(p.CourseId, p, UpdateCache);
                }
                else
                {
                    return null;
                }
            }

            public Task<IEnumerable<ProgrammingCourse>> RetrieveAllAsync()
            {
                // for performance, get from cache
                return Task.FromResult(courseCache is null
                  ? Enumerable.Empty<ProgrammingCourse>() : courseCache.Values);
            }

            public Task<ProgrammingCourse?> RetrieveAsync(int id)
            {
                // for performance, get from cache

                if (courseCache is null) return null!;
            courseCache.TryGetValue(id, out ProgrammingCourse? t);
                return Task.FromResult(t);
            }

            private ProgrammingCourse UpdateCache(int id, ProgrammingCourse t)
            {
            ProgrammingCourse? old;
                if (courseCache is not null)
                {
                    if (courseCache.TryGetValue(id, out old))
                    {
                        if (courseCache.TryUpdate(id, t, old))
                        {
                            return t;
                        }
                    }
                }
                return null!;
            }

            public async Task<ProgrammingCourse?> UpdateAsync(int id, ProgrammingCourse t)
            {
            // normalize customer Id

            t.CourseId = t.CourseId;

                // update in database
                db.ProgrammingCourses.Update(t);
                int affected = await db.SaveChangesAsync();
                if (affected == 1)
                {
                    // update in cache
                    return UpdateCache(id, t);
                }
                return null;
            }

            public async Task<bool?> DeleteAsync(int id)
            {


            // remove from database
            ProgrammingCourse? t = db.ProgrammingCourses.Find(id);
                if (t is null) return null;
                db.ProgrammingCourses.Remove(t);
                int y = await db.SaveChangesAsync();
                if (y == 1)
                {
                    if (courseCache is null) return null;
                    // remove from cache
                    return courseCache.TryRemove(id, out t);
                }
                else
                {
                    return null;
                }
            }

        
    }
    
}
