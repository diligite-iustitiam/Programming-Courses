using Course.Shared;
namespace Course_Server.Repository
{
    public interface ICoursesRepository
        {
            Task<ProgrammingCourse?> CreateAsync(ProgrammingCourse p);
            Task<IEnumerable<ProgrammingCourse>> RetrieveAllAsync();
            Task<ProgrammingCourse?> RetrieveAsync(int id);
            Task<ProgrammingCourse?> UpdateAsync(int id, ProgrammingCourse p);
            Task<bool?> DeleteAsync(int id);
        }
    
}
