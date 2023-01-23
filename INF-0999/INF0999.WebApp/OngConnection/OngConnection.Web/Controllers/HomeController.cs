using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngConnection.Application.DTO;
using OngConnection.Application.Interfaces;
using OngConnection.Domain.Models;
using OngConnection.Web.Models;
using System.Diagnostics;

namespace OngConnection.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IUserServices _userServices;

		public HomeController(ILogger<HomeController> logger, IUserServices userServices)
		{
			_logger = logger;
			_userServices = userServices;
		}

		public IActionResult Index()
		{
			var user = User.Identity == null ? "" : User.Identity.Name;
			return View("Index", new Ong { NomeOng = user!});
		}

		public IActionResult Privacy()
		{
			return View();
		}
	}
}