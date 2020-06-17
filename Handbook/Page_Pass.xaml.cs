using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Handbook {
	/// <summary>
	/// Логика взаимодействия для Page_Pass.xaml
	/// </summary>
	public partial class Page_Pass : Page {
		private string password = "1234";
		public Page_Pass() {
			InitializeComponent();
		}

	

		private void KeyboardClick(object sender, RoutedEventArgs e) {
			string keyPressed = "";
			keyPressed = ((Button)sender).Content.ToString();

			if (keyPressed == "Стерти") {
				if (passwordBox.Password.Length != 0)
					passwordBox.Password = passwordBox.Password.Substring(0, passwordBox.Password.Length - 1);
			}
			else
				passwordBox.Password += keyPressed;
		}

		private void Image_MouseDown_1(object sender, MouseButtonEventArgs e) {
			string enteredPasswrod = passwordBox.Password;
			if (enteredPasswrod == password) {
				Page_AdminPanel p = new Page_AdminPanel();
				NavigationService.Navigate(p);
			}
			else
				passwordBox.Password = "";
		}

		private void Image_MouseDown_2(object sender, MouseButtonEventArgs e) {
			Page_MainWindow p = new Page_MainWindow();
			NavigationService.Navigate(p);
		}
	}
}
