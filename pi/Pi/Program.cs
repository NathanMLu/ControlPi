public class Program {
	static int count = 0;

	private void incrementCounter() {
		count++;
	}

	public static void Main(string[] args) {
		var builder = WebApplication.CreateBuilder(args);
		var app = builder.Build();
		var program = new Program();

		app.MapGet("/", () => { return "Hello World!"; });

		app.MapGet("/increment", () => {
			program.incrementCounter();
			return "Hello World! Count: " + count;
		});

		app.Run();
	}
}