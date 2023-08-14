using student_management.Models;

namespace student_management.Data.Service
{
    public interface IRegistersService
    {
        IEnumerable<Course> GetAll();
        Course GetByCourseId(string courseId);
        Student GetStudentById(string studentId);
        IEnumerable<Student> GetStudents();
        bool IsStudentEnrolledInCourse(string studentId, string courseId);
        bool IsCourseFull(string courseId);
        void EnrollStudentInCourse(string studentId, string courseId);

    }
}
