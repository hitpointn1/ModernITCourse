using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModernITCourse.Configuration;
using ModernITCourse.DataAccessLayer.Entities;
using System.Diagnostics.CodeAnalysis;

namespace ModernITCourse.DataAccessLayer
{
    public class CourseContext : DbContext
    {
        public CourseContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public CourseContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (MigrationConfiguration.IsBuildForMigrations)
            {
                IConfiguration configuration = MigrationConfiguration.Configuration;
                ServiceExtensions.ConfigureOptions(configuration)
                    .Invoke(optionsBuilder);
            }
        }

        public DbSet<University> Universities { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectLecturer> SubjectLecturers { get; set; }
        public DbSet<ExamMarks> ExamMarks { get; set; }
        public DbSet<UpdateInfo> Updates { get; set; }
    }
}
