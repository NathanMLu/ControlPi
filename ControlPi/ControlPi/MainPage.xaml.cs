using System;
using System.Collections.Specialized;
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
			var button = (Button) sender;

			var webClient = new WebClient();
			var response = webClient.UploadValues("http://pi.somee.com/api/toggleled/", "POST", new NameValueCollection());
			var responseString = Encoding.Default.GetString(response);

			if (responseString == "true") {
				button.Text = "LED IS ON";
			} else {
				button.Text = "LED IS OFF";
			}
		}
	}
}