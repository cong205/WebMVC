using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeMVC.Data;
using EmployeeMVC.Models;

namespace EmployeeMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Employees or /
        public async Task<IActionResult> Index()
        {
            var list = await _context.Employees.ToListAsync();
            return View(list);
        }

        // GET: /Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            // debug log (sẽ xuất ra Output window)
            Console.WriteLine($"POST Create: FullName={employee?.FullName}, Email={employee?.Email}");
            if (employee == null)
            {
                return BadRequest("Employee is null");
            }
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // nếu invalid sẽ trả lại view kèm lỗi
            return View(employee);
        }

        // GET: /Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var emp = await _context.Employees.FindAsync(id.Value);
            if (emp == null) return NotFound();
            return View(emp);
        }

        // POST: /Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Employees.Any(e => e.Id == id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var emp = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id.Value);
            if (emp == null) return NotFound();
            return View(emp);
        }

        // GET Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var emp = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id.Value);
            if (emp == null) return NotFound();
            return View(emp);
        }

        // POST DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
