using System.ComponentModel.DataAnnotations;

namespace Course_Site.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public ICollection<Faculty>? Faculties{ get; set; }
    }

}
