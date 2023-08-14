using student_management.Models;

namespace student_management.Data.Service
{
    public interface ICoursesService
    {
        #region CRUD Course
        Task<IEnumerable<Course>> GetAllCourse();
        Task<Course> GetById(string id);
        Task<Course> Update(string courseId, Course cource);
        Task Delete(string id);
        Task Add(Course cource);
        #endregion

    }
}
