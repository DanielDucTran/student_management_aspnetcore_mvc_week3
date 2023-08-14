using student_management.Models;

namespace student_management.Data.Service
{
    public interface IStudentsService
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(string id);
        Task Add(Student student);
        Task<Student> Update(string id, Student newStudent);
        Task Delete(string id);

    }
}
