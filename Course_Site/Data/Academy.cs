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
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

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
            modelBuilder.Entity<Faculty>().ToTable("Faculty");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");

        }
    }
}
