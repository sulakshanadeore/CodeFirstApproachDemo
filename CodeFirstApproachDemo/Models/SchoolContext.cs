using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproachDemo.Models
{
    public class SchoolContext:DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options):base(options)
        {
                
        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Exam> Exams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Teacher>().
                HasOne(e => e.Subject).//1 sub
                WithMany(d => d.Teachers).//M teacher
                HasForeignKey(e => e.SubjectID);
        }

    }
}
