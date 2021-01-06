using GCD0705.AppDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GCD0705.AppDev.Controllers
{
	public class TasksController : Controller
	{
		List<Task> _tasks = new List<Task>
		{
			new Task(1, "Kill John Wick ...", "They killed My Dog !!!", new DateTime(2000, 1, 1, 9, 10, 10)),
			new Task(2, "Kill Bill ...", "Bill must Die !!!", new DateTime(2002, 1, 1, 9, 10, 10)),
			new Task(3, "Kill Romeo ...", "Romeo must Die !!!", new DateTime(2001, 4, 1, 9, 10, 10))
		};
		// GET: Tasks
		Task _task = new Task(1, "Kill John Wick ...", "They killed My Dog !!!", new DateTime(2000, 1, 1, 9, 10, 10));
		public ActionResult Index()
		{
			return View(_tasks);
		}

		public ActionResult Details(int id)
		{
			Task taskInDb = _tasks.SingleOrDefault(t => t.Id == id);
			return View(taskInDb);
		}
	}
}