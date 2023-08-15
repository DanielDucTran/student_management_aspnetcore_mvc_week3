using Microsoft.AspNetCore.Mvc;
using student_management.Data;
using student_management.Data.Service;
using student_management.Models;
using System.Diagnostics;

namespace student_management.Controllers
{
    public class StudentsController : Controller
    {
        private IStudentsService _service;
        public StudentsController(IStudentsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        //Post: Students/Create

        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,FirstName, LastName, DataOfBirth, Address, Gender")]Student student) 
        {
            await _service.Add(student);
            return RedirectToAction(nameof(Index));
        }

        //Get: Students/Detail/id
        public async Task<IActionResult> Details (string id) 
        {
            var studentDetails = await _service.GetById(id);
            if (studentDetails == null)
            {
                return NotFound();
            }
            else
            {
                return View(studentDetails);
            }
        }

        //Get: Students/Edit/id
        public async Task<IActionResult> Edit(string id)
        {
            var studentEdits = await _service.GetById(id);
            if (studentEdits == null)
            {
                return NotFound();
            }
            else
            {
                return View(studentEdits);
            }

            
        }
        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,FirstName, LastName, DataOfBirth, Address, Gender")] Student student)
        {
            
            await _service.Update(student);
            return RedirectToAction(nameof(Index));
        }

        //Get: Students/Delete/id
        public async Task<IActionResult> Delete(string id)
        {
            var deleteStudent = await _service.GetById(id);
            if (deleteStudent == null)
            {
                return NotFound();
            }
            else
            {
                return View(deleteStudent);
            }
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var deleteStudent = await _service.GetById(id);
            if (deleteStudent == null)
            {
                return NotFound();
            }
            
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
