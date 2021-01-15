using GCD0705.AppDev.Models;
using System.Web.Mvc;

namespace GCD0705.AppDev.Controllers
{
	public class CategoriesController : Controller
	{
		// GET: Categories
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public ActionResult Create()
		{
			// Todo
			return View();
		}

		[HttpPost]
		public ActionResult Create(Category category)
		{
			// Todo
			return View();
		}

		public ActionResult Delete(int id)
		{
			// Todo
			return View();
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			// Todo
			return View();
		}

		[HttpPost]
		public ActionResult Edit(Category category)
		{
			// Todo
			return View();
		}
	}
}