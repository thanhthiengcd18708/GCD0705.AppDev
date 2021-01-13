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
	}
}