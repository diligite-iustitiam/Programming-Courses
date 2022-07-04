using Microsoft.EntityFrameworkCore;
using Course_Site.Models;

namespace Course_Site.Data
{
    public class Academy : DbContext
    {
        
        public Academy()
        {

        }
        public Academy(DbContextOptions<Academy> options)
            : base(options)
        {
        }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Faculty>? Courses { get; set; }

        protected override void OnConfiguring(
          DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(
            Environment.CurrentDirectory, "Academy.db");



            optionsBuilder.UseSqlite($"Filename={path}");

            //optionsBuilder.UseSqlServer(@"Data Source = DESKTOP - 5315223\\SQLEXPRESS; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API validation rules

            modelBuilder.Entity<Student>()
              .Property(s => s.StudentId).ValueGeneratedNever();

            // populate database with sample data

            Student alice = new()
            {
                StudentId = 1,
                FirstName = "Alice",
                LastName = "Jones"
            };
            Student bob = new()
            {
                StudentId = 2,
                FirstName = "Bob",
                LastName = "Smith"
            };
            Student cecilia = new()
            {
                StudentId = 3,
                FirstName = "Cecilia",
                LastName = "Ramirez"
            };

            Faculty csharp = new()
            {
                FacultyId = 1,
                Title = "C# 10 and .NET 6",
            };

            Faculty webdev = new()
            {
                FacultyId = 2,
                Title = "Web Development",
            };

            Faculty python = new()
            {
                FacultyId = 3,
                Title = "Python for Beginners",
            };

            modelBuilder.Entity<Student>()
              .HasData(alice, bob, cecilia);

            modelBuilder.Entity<Faculty>()
              .HasData(csharp, webdev, python);

            modelBuilder.Entity<Student>()
              .HasMany(c => c.Faculties)
              .WithMany(s => s.Students)
              .UsingEntity(e => e.HasData(
                // all students signed up for C# course
                new { FacultiesFacultyId = 1, StudentsStudentId = 1 },
                new { FacultiesFacultyId = 1, StudentsStudentId = 2 },
                new { FacultiesFacultyId = 1, StudentsStudentId = 3 },
                // only Bob signed up for Web Dev
                new { FacultiesFacultyId = 2, StudentsStudentId = 2 },
                // only Cecilia signed up for Python
                new { FacultiesFacultyId = 3, StudentsStudentId = 3 }
              ));
        }
    }
}
