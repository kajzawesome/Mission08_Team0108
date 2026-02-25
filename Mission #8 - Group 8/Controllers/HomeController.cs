using Microsoft.AspNetCore.Mvc;
using Mission__8___Group_8.Models;
using System.Diagnostics;

namespace Mission__8___Group_8.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // task quadrant display?
            /* var tasks1 = _context.Tasks.Where(CategoryId = 1).ToList();
             * var tasks2 = _context.Tasks.Where(CategoryId = 2).ToList();
             * var tasks3 = _context.Tasks.Where(CategoryId = 3).ToList();
             * var tasks4 = _context.Tasks.Where(CategoryId = 4).ToList();
             */
            return View();
        }

        // GET: Home/Create 
        public IActionResult Create(Task response)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(response);
                _context.SaveChanges();
                return View("Confirmation", response);
            }

            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "Category");
            return View(response);
        }

        // GET: Home/Confirmation for Create and Update
        public IActionResult Confirmation()
        {
            return View(); 
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _context.Tasks.Find(id);

            if (task == null) {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName", task.CategoryId);
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Task response)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Update(response);
                _context.SaveChanges();
                return View("Confirmation", response);
            }
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "Category");
            return View(response);
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            var task = _context.Tasks.Find(id);
            if (task == null) {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(Task task) {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
