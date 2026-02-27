using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission__8___Group_8.Models;
using SQLitePCL;
using System.Diagnostics;
using System.Linq;

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
            var tasks = _context.GetTasks();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(
                _context.GetCategories(),
                "CategoryId",
                "CategoryName"
            );

            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.TaskItem response)
        {
            if (ModelState.IsValid)
            {
                _context.AddTask(response);
                return RedirectToAction("Confirmation", response);
            }

            ViewBag.Categories = new SelectList(
                _context.GetCategories(),
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
            var task = _context.GetTaskById(id);

            if (task == null) {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(_context.GetCategories(), "CategoryId", "CategoryName", task.CategoryId);
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(Models.TaskItem response)
        {
            if (ModelState.IsValid)
            {
                _context.UpdateTask(response);
                return View("Confirmation", response);
            }
            ViewBag.Categories = new SelectList(_context.GetCategories(), "CategoryId", "CategoryName");
            return View(response);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = _context.GetTaskById(id);
            if (task == null)
                return NotFound();

            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Models.TaskItem task)
        {
            if (task != null)
            {
                _context.DeleteTask(task.TaskId);
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
