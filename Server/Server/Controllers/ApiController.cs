using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers;

public class ApiController : Controller {
	
	// Variable must be static to persist between requests
	private static bool _ledStatus;

	public string Index() {
		return "Why are you trying to access this buddy?";
	}

	[HttpPost]
	public bool LedStatus() {
		// TempData["status"] = _ledStatus;
		return _ledStatus;
	}

	// [HttpPost]
	public bool ToggleLed() {
		_ledStatus = !_ledStatus;
		// TempData["status"] = _ledStatus;
		return _ledStatus;
	}
}