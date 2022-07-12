using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Site.Models
{
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }
        [Required]

        [StringLength(50, MinimumLength = 3)]
        public string? Title { get; set; }
        public string? CourseDescription { get; set; }
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }

        public ICollection<CourseAssignment>? CourseAssignments { get; set; }
        

    }
}
