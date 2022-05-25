using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers;

public class HomeController : Controller {
	private readonly ILogger<HomeController> _logger;

	public HomeController(ILogger<HomeController> logger) {
		_logger = logger;
	}

	public IActionResult Index() {
		try {
			var status = TempData["status"];
			if (status != null) {
				ViewBag.Status = status;
			} else {
				ViewBag.Status = "Click Me";
				ViewBag.Status = false;
			}
			Console.WriteLine("Status: " + status);
		} catch (Exception e) {
			Console.WriteLine("Your error: " + e);
		}
		
		// ViewBag.Status = "test";
		return View();
	}

	public IActionResult About() {
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error() {
		return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
	}
}