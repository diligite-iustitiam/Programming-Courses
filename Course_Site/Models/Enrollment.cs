﻿namespace Course_Site.Models
{
   
        public enum Grade
        {
            A, B, C, D, F
        }

        public class Enrollment
        {
            public int EnrollmentID { get; set; }
            public int FacultyID { get; set; }
            public int StudentID { get; set; }
            public Grade? Grade { get; set; }

            public Faculty Faculty { get; set; }
            public Student Student { get; set; }
        }
    
}
