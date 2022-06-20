using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Courses_Shared
{
    [Table("Programming_Courses")]
    public partial class ProgrammingCourse
    {
        [Key]
        [Column(TypeName = "INT IDENTITY(1,1)")]
        public long CourseId { get; set; }
        [Column(TypeName = "VARCHAR(60)")]
        public string CourseName { get; set; } = null!;
        [Column(TypeName = "VARCHAR(60)")]
        public string Duration { get; set; } = null!;
        [Column(TypeName = "VARCHAR(1000)")]
        public string Description { get; set; } = null!;
        [Column(TypeName = "DECIMAL")]
        public byte[]? Price { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string? FutureJob { get; set; }
    }
}
