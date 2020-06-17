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
	/// Логика взаимодействия для Page_AdminPanel.xaml
	/// </summary>
	public partial class Page_AdminPanel : Page {
		public Page_AdminPanel() {
			InitializeComponent();
		}

		private void MouseDown_Exit(object sender, MouseButtonEventArgs e) {
			Page_MainWindow p = new Page_MainWindow();
			NavigationService.Navigate(p);
		}

		private void MouseDown_EditCost(object sender, MouseButtonEventArgs e) {
			Page_ChooseMedicineCost p = new Page_ChooseMedicineCost();
			NavigationService.Navigate(p);
		}

		private void MouseDown_AddNewInst(object sender, MouseButtonEventArgs e) {
			Page_AddNewInstitution p = new Page_AddNewInstitution();
			NavigationService.Navigate(p);
		}

		private void MouseDown_EditInst(object sender, MouseButtonEventArgs e) {
			Page_ChooseInts p = new Page_ChooseInts();
			NavigationService.Navigate(p);
		}
	}
}
