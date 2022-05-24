using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ControlPi {
	public partial class MainPage : ContentPage {
		public MainPage() {
			InitializeComponent();
		}

		private int count = 0;

		void Handle_Clicked(object sender, System.EventArgs e) {
			count += 3;
			((Button)sender).Text = $"You clicked {count} times.";
		}
	}
}