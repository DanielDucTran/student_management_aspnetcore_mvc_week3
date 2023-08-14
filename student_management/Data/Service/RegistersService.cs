using Microsoft.EntityFrameworkCore;
using student_management.Models;

namespace student_management.Data.Service
{
    public class RegistersService : IRegistersService
    {
        private readonly AppDbContext _context;
        public RegistersService(AppDbContext context)
        {
            _context = context;
        }

        public void EnrollStudentInCourse(string studentId, string courseId)
        {
            var course = GetByCourseId(courseId);
            var student = GetStudentById(studentId);

            if (course != null && student != null)
            {
                if (course.StudentCourses == null)
                {
                    course.StudentCourses = new List<StudentCourse>();
                }

                course.StudentCourses.Add(new StudentCourse { Student = student, Course = course });
                _context.SaveChanges();
            }
        }

        public IEnumerable<Course> GetAll()
        {
            var course = _context.Cources.ToList();
            return course;
        }

        public Course GetByCourseId(string courseId)
        {
            var result = _context.Cources.FirstOrDefault(x => x.CourseId == courseId);
            return result;
        }

        public Student GetStudentById(string studentId)
        {
            var result = _context.Students.FirstOrDefault(x => x.Id == studentId);
            return result;
        }

        public IEnumerable<Student> GetStudents()
        {
            var students = _context.Students.ToList();
            return students;
        }

        public bool IsCourseFull(string courseId)
        {
            var course = _context.Cources.FirstOrDefault(x => x.CourseId == courseId);
            if (course == null)
            {
                return false;
            }

            return course.StudentCourses.Count >= course.MaxStudents;
        }

        public bool IsStudentEnrolledInCourse(string studentId, string courseId)
        {
            return _context.StudentCourses.Any(sc => sc.StudentId == studentId && sc.CourseId == courseId);
        }
    }
}
