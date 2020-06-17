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
	/// Логика взаимодействия для Page_Search.xaml
	/// </summary>
	public partial class Page_Search : Page {
		public Page_Search() {
			InitializeComponent();
		}

		private void Image_MouseDown(object sender, MouseButtonEventArgs e) {
			Page_MainWindow p = new Page_MainWindow();
			NavigationService.Navigate(p);
		}

		private void KeyboardClick(object sender, RoutedEventArgs e) {
			string keyPressed = "";
			if (((Button)sender).Content == null) {
				if (textBox.Text.Length != 0)
					textBox.Text += " ";
			}
			else {
				keyPressed = ((Button)sender).Content.ToString();

				if (keyPressed == "Backspace") {
					if (textBox.Text.Length != 0)
						textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
				}
				else
					textBox.Text += keyPressed;
			}	
		}

		private void Image_MouseDown_1(object sender, MouseButtonEventArgs e) {
			string searchString = textBox.Text;

			if (searchString.Length != 0) {
				Page_ResultSearch p = new Page_ResultSearch(searchString);
				NavigationService.Navigate(p);
			}
		}
	}
}
