using Microsoft.AspNetCore.Mvc;
using student_management.Data;
using student_management.Data.Service;
using student_management.Models;

namespace student_management.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsService _service;
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
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            _service.Add(student);
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

        //
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
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName, LastName, DataOfBirth, Address, Gender")] Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            await _service.Update(id, student);
            return RedirectToAction(nameof(Index));
        }
    }
}
