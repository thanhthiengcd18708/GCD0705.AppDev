using GCD0705.AppDev.Models;
using GCD0705.AppDev.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GCD0705.AppDev.Controllers
{
	[Authorize(Roles = "admin")]
	public class AdminsController : Controller
	{
		private ApplicationDbContext _context;
		private UserManager<ApplicationUser> _userManager;
		public AdminsController()
		{
			_context = new ApplicationDbContext();
			_userManager = new UserManager<ApplicationUser>(
				new UserStore<ApplicationUser>(new ApplicationDbContext())
			);
		}
		// GET: Admins
		public ActionResult Profiles()
		{
			var users = _context.Users.ToList();
			var usersWithRole = new List<UsernameWithRoleViewModel>();

			foreach (var user in users)
			{
				usersWithRole.Add(new UsernameWithRoleViewModel()
				{
					Username = user.UserName,
					Rolename = _userManager.GetRoles(user.Id)[0]
				});
			}
			return View(usersWithRole);
		}
	}
}