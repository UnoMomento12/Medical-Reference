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
	/// Логика взаимодействия для Page_ChooseSubject.xaml
	/// </summary>
	public partial class Page_ChooseSubject : Page {
		public Page_ChooseSubject() {
			InitializeComponent();
		}

		private void Image_MouseDown(object sender, MouseButtonEventArgs e) {
			Page_MainWindow p = new Page_MainWindow();
			NavigationService.Navigate(p);
		}

		private void Image_MouseDown_1(object sender, MouseButtonEventArgs e) {
			Page_Organ p = new Page_Organ();
			NavigationService.Navigate(p);
		}

		private void Image_MouseDown_2(object sender, MouseButtonEventArgs e) {
			Page_ChooseSickness p = new Page_ChooseSickness();
			NavigationService.Navigate(p);
		}

		private void Image_MouseDown_3(object sender, MouseButtonEventArgs e) {
			Page_ChooseMedicine p = new Page_ChooseMedicine();
			NavigationService.Navigate(p);
		}
	}
}
