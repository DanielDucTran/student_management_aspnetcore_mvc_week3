using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using student_management.Data;
using student_management.Data.Service;
using student_management.Models;

namespace student_management.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICoursesService _service;
        public CoursesController(ICoursesService service)
        {
            _service = service;
        }

        #region CRUD Courses - Data Service
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllCourse();
            return View(data);
        }

        //Get: Course/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Course cource)
        {
            _service.Add(cource);
            return RedirectToAction(nameof(Index));
        }

        //Get: Course/Detail

        public async Task<IActionResult> Details(string id)
        {
            var courseDetail = await _service.GetById(id);
            if (courseDetail == null)
            {
                return NotFound();
            }
            return View(courseDetail);
        }

        //Get: Course/Edit/id
        public async Task<IActionResult> Edit(string id)
        {
            var editCourse = await _service.GetById(id);
            if (editCourse == null)
            {
                return NotFound();
            }
            return View(editCourse);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id, Course course)
        {
            await _service.Update(id, course);
            return RedirectToAction(nameof(Index));
        }

        //Get: Course/Delete/id
        public async Task<IActionResult> Delete(string id) 
        {
            var deleteCourse = await _service.GetById(id);
            if (deleteCourse == null)
            {
                return NotFound();
            }
            else
            {
                return View(deleteCourse);
            }
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id) 
        {
            var deleteCourse = await _service.GetById(id);
            if (!ModelState.IsValid) 
            {
                return NotFound();
            }
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
