using Microsoft.AspNetCore.Mvc;

public class Program {
	private bool ledStatus;

	private bool GetLedStatus() {
		return ledStatus;
	}

	private bool ToggleLed() {
		ledStatus = !ledStatus;
		return ledStatus;
	}


	public static void Main(string[] args) {
		var builder = WebApplication.CreateBuilder(args);
		var app = builder.Build();
		var program = new Program();

		app.MapGet("/", HomePage);
		app.MapGet("/ledStatus", () => program.GetLedStatus());
		app.MapGet("/toggleLed", () => program.ToggleLed());

		app.Run();
	}


	private static ContentResult HomePage() {
		return new ContentResult {
			Content = "<html><body><h1>Hello World!</h1></body></html>"
		};
	}
}