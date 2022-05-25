using System;
using System.Device.Gpio;
using System.Threading;
using System.Net;

class Program {
    private void ListenLed(int pin) {

        // Pin Controller
        // var controller = new GpioController();
        // controller.OpenPin(pin, PinMode.Output);

        // Request
        var url = "http://pi.somee.com/ledStatus";

        while (true) {
            var request = WebRequest.Create(url);
            request.Method = "GET";
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream);
            var data = reader.ReadToEnd();
            
            Console.WriteLine(data);

            // if (data == "true") {
            //     Console.WriteLine("On");
            //     controller.Write(pin, PinValue.High);
            // } else {
            //     Console.WriteLine("off");
            //     controller.Write(pin, PinValue.Low);
            // }
            Thread.Sleep(1000);

            // controller.Write(pin, PinValue.High);
            // Thread.Sleep(1000);
            // controller.Write(pin, PinValue.Low);
            // Thread.Sleep(1000);
        }
    }

    static void Main(string[] args) {
        var program = new Program();
        int pin = 17;
        program.ListenLed(pin);

        Console.WriteLine("Toggling LED: " + pin);
    }
}