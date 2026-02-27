using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission__8___Group_8.Models;
using SQLitePCL;
using System.Diagnostics;

namespace Mission__8___Group_8.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _context;

        public HomeController(ITaskRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var tasks = _context.Tasks.ToList();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(
                _context.Categories.ToList(),
                "CategoryId",
                "CategoryName"
            );

            return View();
        }

        [HttpPost]
        public IActionResult Create(Task response)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(response);
                _context.SaveChanges();
                return RedirectToAction("Confirmation", response);
            }

            ViewBag.Categories = new SelectList(
                _context.Categories.ToList(),
                "CategoryId",
                "CategoryName"
            );

            return View(response);
        }

        [HttpPost]
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
            return View(task);
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
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
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
        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
