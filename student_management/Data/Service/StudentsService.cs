using Microsoft.EntityFrameworkCore;
using student_management.Models;

namespace student_management.Data.Service
{
    public class StudentsService : IStudentsService
    {
        public readonly AppDbContext _context;
        public StudentsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Student student)
        {
             await _context.Students.AddAsync(student);
             await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var result = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            _context.Students.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            var result = await _context.Students.ToListAsync();
            return result;
        }

        public async Task<Student> GetById(string id)
        {
            var result = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Student> Update(string id, Student newStudent)
        {
            _context.Update(newStudent);
            await _context.SaveChangesAsync();
            return newStudent;
        }
    }
}
