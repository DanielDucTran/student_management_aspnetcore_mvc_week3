using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using student_management.Data;
using student_management.Data.Service;
using student_management.Models;

namespace student_management.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegistersService _service;
        public RegisterController(IRegistersService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var course = _service.GetAll();
            return View(course);
        }
        public IActionResult Enroll(string courseId)
        {
            var course = _service.GetByCourseId(courseId);
            if (course == null)
            {
                return NotFound();
            }
            var students = _service.GetStudents();
            ViewBag.CourseId = courseId;
            ViewBag.Students = new SelectList((System.Collections.IEnumerable)students, "Id", "LastName");
            return View();
        }
        [HttpPost]
        public IActionResult Enroll(string courseId, string studentId)
        {
            var course = _service.GetByCourseId(courseId);
            var student = _service.GetStudentById(studentId);

            if (course == null || student == null)
            {
                return NotFound();
            }
            if (_service.IsStudentEnrolledInCourse(studentId, courseId))
            {
                ModelState.AddModelError("", "Bạn đã đăng kí khóa học này!");
                var students = _service.GetStudents();
                ViewBag.CourseId = courseId;
                ViewBag.Students = new SelectList(students,"Id", "LastName");
                return View();
            }
            if (_service.IsCourseFull(courseId))
            {
                ModelState.AddModelError("", "Môn học đã đầy slot!");
                var students = _service.GetStudents();
                ViewBag.CourseId = courseId;
                ViewBag.Students = new SelectList(students, "Id", "LastName");
                return View();
            }
            _service.EnrollStudentInCourse(studentId,courseId);

            return RedirectToAction(nameof(Index));
        }
    }
}
