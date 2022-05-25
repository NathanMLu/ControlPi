using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers;

public class HomeController : Controller {
	private readonly ILogger<HomeController> _logger;

	public HomeController(ILogger<HomeController> logger) {
		_logger = logger;
	}

	public IActionResult Index() {
		// var client = new HttpClient();
		// var url = "http://pi.somee.com/ledStatus";
		// var response = client.GetAsync(url).Result;
		// var result = response.Content.ReadAsStringAsync().Result;
		// Console.WriteLine(result);

		
		ViewBag.Status = "test";

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