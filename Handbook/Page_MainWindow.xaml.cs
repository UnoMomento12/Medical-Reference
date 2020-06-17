using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Threading;

namespace Handbook {
	/// <summary>
	/// Логика взаимодействия для Page_MainWindow.xaml
	/// </summary>
	public partial class Page_MainWindow : Page {
		public Page_MainWindow() {
			InitializeComponent();


			textBlock_time.Text = DateTime.Now.ToString("HH:mm");
			DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 1, 0), DispatcherPriority.Normal, delegate
			{
				textBlock_time.Text = DateTime.Now.ToString("HH:mm"); 
			}, Dispatcher);


			//string sDate = DateTime.Now.ToString();
			DateTime datevalue = (Convert.ToDateTime(DateTime.Now));

			string dy = datevalue.Day.ToString();
			int mn = datevalue.Month;
			string yy = datevalue.Year.ToString();
			string month = "";

			switch (mn) {
				case 1: month = "Січеня"; break;
				case 2: month = "Лютого"; break;
				case 3: month = "Березня"; break;
				case 4: month = "Квітня"; break;
				case 5: month = "Травня"; break;
				case 6: month = "Червня"; break;
				case 7: month = "Липня"; break;
				case 8: month = "Серпня"; break;
				case 9: month = "Вересня"; break;
				case 10: month = "Жовтня"; break;
				case 11: month = "Листопада"; break;
				case 12: month = "Грудня"; break;
			}

				textBlock_day.Text += dy + " " + month + " " + yy;

		}

		private void button_search_MouseDown(object sender, MouseButtonEventArgs e) {
			Page_Search p = new Page_Search();
			NavigationService.Navigate(p);
		}

		private void button_choose_subject_MouseDown(object sender, MouseButtonEventArgs e) {
			Page_ChooseSubject p = new Page_ChooseSubject();
			NavigationService.Navigate(p);
		}

		private void button_institutions_MouseDown(object sender, MouseButtonEventArgs e) {
			Page_Institutions p = new Page_Institutions();
			NavigationService.Navigate(p);
		}

		private void button_admin_root_MouseDown(object sender, MouseButtonEventArgs e) {
			Page_Pass p = new Page_Pass();
			NavigationService.Navigate(p);
		}

		
	}
}
