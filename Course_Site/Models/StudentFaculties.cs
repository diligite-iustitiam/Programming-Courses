namespace Course_Site.Models
{
    public class StudentFaculties
    {
        public int Id { get; set; }
        public int FacultyId { get; set; }
        public int StudentId { get; set; }
        public Student student { get; set; }
        public Faculty faculty { get; set; }
    }
}
