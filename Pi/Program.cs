using System;
using System.Device.Gpio;
using System.Threading;

class Program {
    private void ToggleLed(int pin) {

        var controller = new GpioController();
        controller.OpenPin(pin, PinMode.Output);

        while (true) {
            controller.Write(pin, PinValue.High);
            Thread.Sleep(500);
            controller.Write(pin, PinValue.Low);
            Thread.Sleep(500);
        }
    }

    static void Main(string[] args) {
        var program = new Program();
        int pin = 17;
        program.ToggleLed(pin);
        
        Console.WriteLine("Toggling LED: " + pin);
    }
}