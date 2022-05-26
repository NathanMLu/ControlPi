using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ControlPi {
	public partial class MainPage : ContentPage {
		public MainPage() {
			InitializeComponent();
			// Run update UI on separate thread
			Thread t = new Thread(UpdateUi);
			t.Start();
		}

		private void UpdateUi() {
			Button button = this.FindByName<Button>("ToggleButton");
			while (true) {
				try {
					var webClient = new WebClient();
					var response = webClient.UploadValues("https://pi.somee.com/api/ledstatus/", "POST",
						new NameValueCollection());
					var responseString = Encoding.Default.GetString(response);

					if (responseString == "true") {
						Device.BeginInvokeOnMainThread(() => {
							button.Text = "LED IS ON";
						});
					}
					else {
						Device.BeginInvokeOnMainThread(() => {
							button.Text = "LED IS OFF";
						});
					}
				}
				catch (System.Exception) {
					Console.WriteLine("Error");
					throw;
				}

				Thread.Sleep(1000);
			}
		}

		public void ToggleLed(object sender, System.EventArgs e) {
			var button = (Button) sender;

			var webClient = new WebClient();
			var response =
				webClient.UploadValues("https://pi.somee.com/api/toggleled/", "POST", new NameValueCollection());
			var responseString = Encoding.Default.GetString(response);

			if (responseString == "true") {
				button.Text = "LED IS ON";
			}
			else {
				button.Text = "LED IS OFF";
			}
		}
	}
}