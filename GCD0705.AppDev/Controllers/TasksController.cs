using GCD0705.AppDev.Models;
using System;
using System.Web.Mvc;

namespace GCD0705.AppDev.Controllers
{
	public class TasksController : Controller
	{
		// GET: Tasks
		Task _task = new Task(1, "Kill John Wick ...", "They killed My Dog !!!", new DateTime(2000, 1, 1, 9, 10, 10));
		public ActionResult Index()
		{
			return View(_task);
		}
	}
}