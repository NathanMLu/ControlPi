using System;
using System.Device.Gpio;
using System.Threading;
using System.Net;

class Program {
    private async void ListenLed(int pin) {
        Console.WriteLine("Starting to Listen");

        // Pin Controller
        var controller = new GpioController();
        controller.OpenPin(pin, PinMode.Output);

        Console.WriteLine("Still Listening");

        // Request
        // var url = "http://pi.somee.com/ledStatus";
        // var request = WebRequest.Create(url);
        // request.Method = "GET";

        while (true) {
            // var url = "http://pi.somee.com/ledStatus";
            // var client = new HttpClient();
            // var response = await client.GetAsync(url);
            // var content = await response.Content.ReadAsStringAsync();
            // Console.WriteLine("Hello There");
            // Console.WriteLine(content);


            // var response = request.GetResponse();
            // var stream = response.GetResponseStream();
            // var reader = new StreamReader(stream);
            // var data = reader.ReadToEnd();

            // if (data == "true") {
            //     controller.Write(pin, PinValue.High);
            // } else {
            //     controller.Write(pin, PinValue.Low);
            // }
            // Thread.Sleep(1000);

            controller.Write(pin, PinValue.High);
            Thread.Sleep(1000);
            controller.Write(pin, PinValue.Low);
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