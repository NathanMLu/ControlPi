using System;
using System.Device.Gpio;
using System.Threading;
using System.Net;

class Program {
	private void ListenLed(int pin) {
		// Pin Controller
		var controller = new GpioController();
		controller.OpenPin(pin, PinMode.Output);

		// Request
		var url = "http://pi.somee.com/ledStatus";

		while (true) {
			try {
				// Calling Request
				var request = WebRequest.Create(url);
				request.Method = "GET";
				var response = request.GetResponse();
				var stream = response.GetResponseStream();
				var reader = new StreamReader(stream);
				var data = reader.ReadToEnd().ToString();

				// Switching Led
				if (data == "true") {
					controller.Write(pin, PinValue.High);
				}
				else {
					controller.Write(pin, PinValue.Low);
				}
			}
			catch (System.Exception) {
				Console.WriteLine("Error");
				throw;
			}
			
			// Waiting for one second
			Thread.Sleep(1000);
		}
	}

	static void Main(string[] args) {
		var program = new Program();
		int pin = 17;
		program.ListenLed(pin);

		Console.WriteLine("Toggling LED: " + pin);
	}
}