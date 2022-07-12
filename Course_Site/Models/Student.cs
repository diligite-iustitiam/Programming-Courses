
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Site.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [StringLength(60)]
        [Display(Name = "Student Name")]
        public string? StudentName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [Required]
        int Age { get; set; }
        [Required]
        public DateTime? StudentBirthDate { get; set; }
        [Required]
        [Display(Name = "Enrollment Date")]
        public DateTime RegTime { get; set; }
        
       

    }
}
