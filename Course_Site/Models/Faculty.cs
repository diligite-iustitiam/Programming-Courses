using System.ComponentModel.DataAnnotations;

namespace Course_Site.Models
{
    public class Faculty
    {
        
        public int FacultyId { get; set; }

        
        public string? Title { get; set; }

        public ICollection<Student>? Students { get; set; }
        public ICollection<StudentFaculties>? StudentFaculties { get; set; }
    }
}
