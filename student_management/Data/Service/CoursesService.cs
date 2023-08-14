using Microsoft.EntityFrameworkCore;
using student_management.Models;

namespace student_management.Data.Service
{
    public class CoursesService : ICoursesService
    {
        private readonly AppDbContext _context;
        public CoursesService(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Course cource)
        {
            await _context.AddAsync(cource);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(string id)
        {
            var result = await _context.Cources.FirstOrDefaultAsync(x => x.CourseId == id);
            _context.Cources.Remove(result);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Course>> GetAllCourse()
        {
            var courses = await _context.Cources.ToListAsync();
            return courses;
        }
        public async Task<Course> GetById(string id)
        {
            var result = await _context.Cources.FirstOrDefaultAsync(x => x.CourseId==id);
            return result;
        }
        public async Task<Course> Update(string courseId, Course newCource)
        {
            _context.Update(newCource);
            await _context.SaveChangesAsync();
            return newCource;
        }
    }
}
