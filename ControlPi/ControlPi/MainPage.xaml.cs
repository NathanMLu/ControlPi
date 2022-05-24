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
			
			var url = "http://pi.somee.com/toggleled";
			var request = WebRequest.Create(url);
			request.Method = "GET";

			var webResponse = request.GetResponse();
			var webStream = webResponse.GetResponseStream();
		
			var reader = new StreamReader(webStream);
			var data = reader.ReadToEnd();

			button.Text = data;

			// if (result == "1") {
			// 	button.Text = "LED is on";
			// } else {
			// 	button.Text = "LED is off";
			//
			// button.Text = response.ToString();
		}
	}
}