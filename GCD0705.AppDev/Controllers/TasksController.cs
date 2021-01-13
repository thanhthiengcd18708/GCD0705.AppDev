using GCD0705.AppDev.Models;
using System.Linq;
using System.Web.Mvc;

namespace GCD0705.AppDev.Controllers
{
	public class TasksController : Controller
	{
		private ApplicationDbContext _context;
		public TasksController()
		{
			_context = new ApplicationDbContext();
		}
		// GET: Tasks
		public ActionResult Index()
		{
			return View(_context.Tasks.ToList());
		}

		public ActionResult Details(int id)
		{
			Task taskInDb = _context.Tasks.SingleOrDefault(t => t.Id == id);
			return View(taskInDb);
		}

		public ActionResult Delete(int id)
		{
			var taskInDb = _context.Tasks.SingleOrDefault(t => t.Id == id);

			if (taskInDb == null) return HttpNotFound();

			_context.Tasks.Remove(taskInDb);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Task task)
		{
			var newTask = new Task()
			{
				Name = task.Name,
				Description = task.Description,
				DueDate = task.DueDate
			};

			_context.Tasks.Add(newTask);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			return View();
		}

		[HttpPost]
		public ActionResult Edit(Task task)
		{
			return RedirectToAction("Index");
		}
	}
}