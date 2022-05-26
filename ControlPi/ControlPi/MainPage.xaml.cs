using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ControlPi {
	public partial class MainPage : ContentPage {
		public MainPage() {
			InitializeComponent();
		}

		public void ToggleLed(object sender, System.EventArgs e) {
			var button = (Button)sender;
			button.Text = "Loading...";
			
			var url = "http://pi.somee.com/api/toggleled";
			var request = WebRequest.Create(url);
			request.Method = "GET";

			var webResponse = request.GetResponse();
			var webStream = webResponse.GetResponseStream();

			if (webStream != null) {
				var reader = new StreamReader(webStream);
				var data = reader.ReadToEnd();

				if (data == "true") {
					button.Text = "LED is ON";
				} else {
					button.Text = "LED is OFF";
				}
			}
		}
	}
}