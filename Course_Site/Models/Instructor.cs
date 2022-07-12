using System.ComponentModel.DataAnnotations;

namespace Course_Site.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }

        [Required]
        [Display(Name = "Instructor Name")]
        [StringLength(50)]
        public string? InstructorName{ get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        public OfficeAssignment? OfficeAssignment { get; set; }

    }
}
