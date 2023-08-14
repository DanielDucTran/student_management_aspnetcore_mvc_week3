using Microsoft.EntityFrameworkCore;
using student_management.Models;

namespace student_management.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(x => new
            {
                x.CourseId,
                x.StudentId
            });
            modelBuilder.Entity<StudentCourse>().HasOne(x => x.Course).WithMany(x => x.StudentCourses).HasForeignKey(x => x.CourseId);
            modelBuilder.Entity<StudentCourse>().HasOne(x => x.Student).WithMany(x => x.StudentCourses).HasForeignKey(x => x.StudentId);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Cources { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
    }
}
