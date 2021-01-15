﻿using GCD0705.AppDev.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GCD0705.AppDev.Controllers
{
	public class TasksController : Controller
	{
		private ApplicationDbContext _context;
		private UserManager<ApplicationUser> _userManager;
		public TasksController()
		{
			_context = new ApplicationDbContext();
		}
		// GET: Tasks
		public ActionResult Index(string searchString)
		{
			var tasks = _context.Tasks.ToList();

			if (!searchString.IsNullOrWhiteSpace())
			{
				tasks = _context.Tasks
					.Where(t => t.Name.Contains(searchString))
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
			if (!ModelState.IsValid)
			{
				return View();
			}
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
			var taskInDb = _context.Tasks.SingleOrDefault(t => t.Id == id);
			if (taskInDb == null) return HttpNotFound();

			return View(taskInDb);
		}

		[HttpPost]
		public ActionResult Edit(Task task)
		{
			if (!ModelState.IsValid)
			{
				return View(task);
			}
			var taskInDb = _context.Tasks.SingleOrDefault(t => t.Id == task.Id);

			taskInDb.Name = task.Name;
			taskInDb.Description = task.Description;
			taskInDb.DueDate = task.DueDate;

			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}