using System;
using System.Collections.Generic;
using System.Data;
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
	/// Логика взаимодействия для Page_MedicineCost.xaml
	/// </summary>
	public partial class Page_MedicineCost : Page {
		private string med;
		public Page_MedicineCost(string medicine) {
			InitializeComponent();
			med = medicine;
			LoadData(medicine);
		}

	
		private void LoadData (string medicine) {
			string sql = String.Format(@"SELECT * FROM medicine WHERE title = ""{0}"";", medicine);

			Connection conn;
			conn = Connection.GetConnection("");

			DataSet ds = new DataSet();
			ds = conn.SelecteQuery(sql);

			textBlock_Title.Text += ds.Tables[0].Rows[0][1].ToString();

			textBlock_PastCost.Text += ds.Tables[0].Rows[0][13].ToString();
			textBlock_PastCost.Text += " грн.";

		}

		private void KeyboardClick(object sender, RoutedEventArgs e) {
			string keyPressed = "";
			keyPressed = ((Button)sender).Content.ToString();

			if (keyPressed == "Стерти") {
				if (textBox_NewCost.Text.Length != 0)
					textBox_NewCost.Text = textBox_NewCost.Text.Substring(0, textBox_NewCost.Text.Length - 1);
			}
			else if (keyPressed == ",") {
				if (!textBox_NewCost.Text.Contains(",")) {
					if (textBox_NewCost.Text.Length != 0)
						textBox_NewCost.Text += keyPressed;
				}

			}
			else {
				if (textBox_NewCost.Text.Contains(",")) {
					int it = textBox_NewCost.Text.Length - textBox_NewCost.Text.IndexOf(",");
					if (it <= 2)
						textBox_NewCost.Text += keyPressed;
					
				}
				else
					textBox_NewCost.Text += keyPressed;
			}
		}

		private void MouseDown_Save(object sender, MouseButtonEventArgs e) {
			//string sqlBase = @"UPDATE medicine SET price = {0} WHERE title = ""{1}""";
			string sqlBase = @"CALL update_cost({0}, ""{1}"");";
			Connection conn;
			conn = Connection.GetConnection("");

			string newCost = textBox_NewCost.Text;
			newCost = newCost.Replace(",", ".");
			string sql = String.Format(sqlBase, newCost, med);

			Page_AdminPanel p = new Page_AdminPanel();
			NavigationService.Navigate(p);
		}

		private void MouseDown_BackToAdminPanel(object sender, MouseButtonEventArgs e) {
			Page_AdminPanel p = new Page_AdminPanel();
			NavigationService.Navigate(p);
		}
	}
}
