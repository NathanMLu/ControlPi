public class Program {
	bool ledStatus = false;
	
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

		app.MapGet("/", () => {
			return DateTime.Now.ToString();
		});
		app.MapGet("/ledStatus", () => program.GetLedStatus());
		app.MapGet("/toggleLed", () => program.ToggleLed());
		
		app.Run();
	}
}