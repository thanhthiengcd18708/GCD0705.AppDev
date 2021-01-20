using GCD0705.AppDev.Models;
using GCD0705.AppDev.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GCD0705.AppDev.Controllers
{
	[Authorize(Roles = "user")]
	public class TasksController : Controller
	{
		private ApplicationDbContext _context;
		public TasksController()
		{
			_context = new ApplicationDbContext();
		}
		// GET: Tasks
		public ActionResult Index(string searchString)
		{
			var currentUserId = User.Identity.GetUserId();
			var tasks = _context.TaskUsers
				.Where(m => m.ApplicationUserId == currentUserId)
				.Select(m => m.Task)
				.Include(m => m.Category)
				.ToList();

			if (!searchString.IsNullOrWhiteSpace())
			{
				tasks = _context.TaskUsers
				.Where(m => m.ApplicationUserId == currentUserId && m.Task.Name.Contains(searchString))
				.Select(m => m.Task)
				.Include(m => m.Category)
				.ToList();
			}

			return View(tasks);
		}

		public ActionResult Details(int id)
		{
			Task taskInDb = _context.Tasks.SingleOrDefault(t => t.Id == id);
			return View(taskInDb);
		}

		public ActionResult Delete(int id)

		{

			var currentUserId = User.Identity.GetUserId();
			var taskUserInDb = _context.TaskUsers
				.SingleOrDefault(t => t.TaskId == id && t.ApplicationUserId == currentUserId);

			_context.TaskUsers.Remove(taskUserInDb);

			var taskInDb = _context.Tasks.SingleOrDefault(t => t.Id == id);

			if (taskInDb == null) return HttpNotFound();

			_context.Tasks.Remove(taskInDb);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Create()
		{
			var viewModel = new TaskCategoriesViewModel()
			{
				Categories = _context.Categories.ToList()
			};
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Create(Task task)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var newTask = new Task()
			{
				Name = task.Name,
				Description = task.Description,
				DueDate = task.DueDate,
				CategoryId = task.CategoryId
			};

			_context.Tasks.Add(newTask);

			var userId = User.Identity.GetUserId();
			var taskUser = new TaskUser()
			{
				TaskId = newTask.Id,
				ApplicationUserId = userId
			};

			_context.TaskUsers.Add(taskUser);

			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var taskInDb = _context.Tasks.SingleOrDefault(t => t.Id == id);
			if (taskInDb == null) return HttpNotFound();

			var viewModel = new TaskCategoriesViewModel()
			{
				Task = taskInDb,
				Categories = _context.Categories.ToList()
			};
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Edit(Task task)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new TaskCategoriesViewModel()
				{
					Task = task,
					Categories = _context.Categories.ToList()
				};
				return View(viewModel);
			}
			var taskInDb = _context.Tasks.SingleOrDefault(t => t.Id == task.Id);

			taskInDb.Name = task.Name;
			taskInDb.Description = task.Description;
			taskInDb.DueDate = task.DueDate;
			taskInDb.CategoryId = task.CategoryId;

			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}