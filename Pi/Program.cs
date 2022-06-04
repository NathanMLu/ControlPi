using System.Device.Gpio;
using System.Net;

namespace Pi;

internal class Program
{
    private static void ListenLed(int pin)
    {
        // Pin Controller
        var controller = new GpioController();
        controller.OpenPin(pin, PinMode.Output);

        // Request
        const string url = "https://pi.somee.com/api/ledStatus";

        while (true)
        {
            // Calling Request
            try
            {
                var request = WebRequest.Create(url);
                request.Method = "POST";
                var response = request.GetResponse();
                var stream = response.GetResponseStream();
                var reader = new StreamReader(stream);
                var data = reader.ReadToEnd();

                // Switching Led
                controller.Write(pin, data == "true" ? PinValue.High : PinValue.Low);
            }
            catch (System.Exception)
            {
                Console.WriteLine("Error");
                throw;
            }

            // Waiting for one second
            Thread.Sleep(1000);
        }
    }

    private static void Main()
    {
        var program = new Program();
        const int pin = 17;
        ListenLed(pin);

        Console.WriteLine("Toggling LED: " + pin);
    }
}