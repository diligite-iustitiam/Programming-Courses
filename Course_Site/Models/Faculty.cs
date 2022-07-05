using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Site.Models
{
    public class Faculty
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FacultyID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
