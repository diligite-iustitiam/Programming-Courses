using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Course.Shared
{
    [Table("Programming_Courses")]
    public partial class ProgrammingCourse
    {
        [Key]
        [Column(TypeName = "INT IDENTITY(1,1)")]
        public int CourseId { get; set; }
        [Column(TypeName = "VARCHAR(60)")]
        public string CourseName { get; set; } = null!;
        [Column(TypeName = "VARCHAR(60)")]
        public string Duration { get; set; } = null!;
        [Column(TypeName = "VARCHAR(1000)")]
        public string Description { get; set; } = null!;
        [Column(TypeName = "DECIMAL")]
        public decimal Price { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string? FutureJob { get; set; }
    }
}
