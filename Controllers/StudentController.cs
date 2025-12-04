using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsDatabase.Data;
using StudentsDatabase.Entities;
using StudentsDatabase.Models;

namespace StudentsDatabase.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Id,Name,Email,Phone,Address")] StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                Student obj = new Student();
                obj.Name = student.Name;
                obj.Email = student.Email;
                obj.Phone = student.Phone;
                obj.Address = student.Address;
                _context.Add(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            var model = new StudentViewModel();
            model.Id = student.Id;
            model.Name = student.Name;
            model.Email = student.Email;
            model.Phone = student.Phone;
            model.Address = student.Address;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[Bind("Id,Name,Email,Phone,Address")] StudentViewModel student)
        {
            if (id != student.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var obj = new Student
                {
                    Id = student.Id,
                    Name = student.Name,
                    Email = student.Email,
                    Phone = student.Phone,
                    Address = student.Address
                };
                _context.Update(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
