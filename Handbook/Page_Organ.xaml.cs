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
	/// Логика взаимодействия для Page_Organ.xaml
	/// </summary>
	public partial class Page_Organ : Page {
		public Page_Organ() {
			InitializeComponent();
		}

		// * * * * * * * * * * * * * * * * * * * * * * * * * * * *
		// * *   EVENT ON ORGAN ELLIPSE - MouseDown    * * * * * * 
		// * * * * * * * * * * * * * * * * * * * * * * * * * * * *




		private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			switch(listView.SelectedIndex) {
				case 0:
					GoToSymptom("Вуха");
					break;

				case 1:
					GoToSymptom("Голова");
					break;

				case 2:
					GoToSymptom("Груди");
					break;

				case 3:
					GoToSymptom("Живіт");
					break;

				case 4:
					GoToSymptom("Ніс");
					break;

				case 5:
					GoToSymptom("Ноги");
					break;

				case 6:
					GoToSymptom("Очі");
					break;

				case 7:
					GoToSymptom("Передпліччя");
					break;

				case 8:
					GoToSymptom("Психологічне здоров'я");
					break;

				case 9:
					GoToSymptom("Рот");
					break;

				case 10:
					GoToSymptom("Руки");
					break;

				case 11:
					GoToSymptom("Спина");
					break;

				case 12:
					GoToSymptom("Фізичне здоров'я");
					break;

				case 13:
					GoToSymptom("Шия");
					break;

				case 14:
					GoToSymptom("Шкіра");
					break;

				case 15:
					GoToSymptom("Ступні");
					break;
			}
		}
		
		private void GoToSymptom(string organ) {
			Page_ChooseSymptom p = new Page_ChooseSymptom(organ);
			NavigationService.Navigate(p);
		}

		private void Image_MouseDown(object sender, MouseButtonEventArgs e) {
			Page_MainWindow p = new Page_MainWindow();
			NavigationService.Navigate(p);
		}

		private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e) {
			string name = ((Ellipse)sender).Name;

			switch (name) {
				case "_1":
					GoToSymptom("Голова");
					break;

				case "_2":
					GoToSymptom("Спина");
					break;

				case "_3":
					GoToSymptom("Очі");
					break;

				case "_4":
					GoToSymptom("Ніс");
					break;

				case "_5":
					GoToSymptom("Рот");
					break;

				case "_6":
					GoToSymptom("Вуха");
					break;

				case "_7":
					GoToSymptom("Шкіра");
					break;

				case "_8":
					GoToSymptom("Фізичне здоров'я");
					break;

				case "_9": GoToSymptom("Психологічне здоров'я");
					break;

				case "_10":
					GoToSymptom("Шия");
					break;

				case "_11":
					GoToSymptom("Груди");
					break;

				case "_12":
					GoToSymptom("Живіт");
					break;

				case "_13":
					GoToSymptom("Ноги");
					break;

				case "_14":
					GoToSymptom("Передпліччя");
					break;

				case "_15":
					GoToSymptom("Руки");
					break;

				case "_16":
					GoToSymptom("Ступні");
					break;

			}
		}
	}
}
