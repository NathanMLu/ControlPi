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
		// URL Request from API
		// TODO: Update to api directory
		var url = "http://pi.somee.com/api/ledStatus";
		var request = WebRequest.Create(url);
		request.Method = "POST";
		
		// Calling Request
		var response = request.GetResponse();
		var responseStream = response.GetResponseStream();
		var reader = new StreamReader(responseStream);
		var responseFromServer = reader.ReadToEnd().ToString();
		
		// Displaying Response		
		if (responseFromServer == "true") {
			ViewBag.Status = "LED IS ON";
		} else {
			ViewBag.Status = "LED iS OFF";
		}
		
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