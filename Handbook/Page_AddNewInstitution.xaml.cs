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
	/// Логика взаимодействия для Page_AddNewInstitution.xaml
	/// </summary>
	public partial class Page_AddNewInstitution : Page {
		private TextBox focusTextBox;
		public Page_AddNewInstitution() {
			InitializeComponent();
			
			focusTextBox = textBox_Title;
			LoadData();
		}

		private void LoadData() {
			string sql = @"SELECT kind FROM types";

			Connection conn;
			conn = Connection.GetConnection("");

			DataSet ds = new DataSet();
			ds = conn.SelecteQuery(sql);	

			foreach (DataRow row in ds.Tables[0].Rows) {
				comboBox.Items.Add(row[0].ToString());
			}

			comboBox.SelectedIndex = -1;
		}

	


		private void KeyboardClick(object sender, RoutedEventArgs e) {
			string keyPressed = "";

			if (focusTextBox.Name.ToString() != "textBox_Phone") {
				if (((Button)sender).Content == null) {
					focusTextBox.Text += " ";
				}
				else {
					keyPressed = ((Button)sender).Content.ToString();

					if (keyPressed == "Backspace") {
						if (focusTextBox.Text.Length != 0)
							focusTextBox.Text = focusTextBox.Text.Substring(0, focusTextBox.Text.Length - 1);
					}
					else
						focusTextBox.Text += keyPressed;
				}
			} 
			else {
				if (((Button)sender).Content != null) {
					keyPressed = ((Button)sender).Content.ToString();
					if (keyPressed.Any(char.IsDigit))
						focusTextBox.Text += keyPressed;
					else if (keyPressed == "Backspace")
						if (focusTextBox.Text.Length != 0)
							focusTextBox.Text = focusTextBox.Text.Substring(0, focusTextBox.Text.Length - 1);
				}
			}
		}

		public void SelectedTextBox(object sender, RoutedEventArgs e) {
			focusTextBox = (TextBox)sender;
		}

		private void Image_MouseDown(object sender, MouseButtonEventArgs e) {
			Page_AdminPanel p = new Page_AdminPanel();
			NavigationService.Navigate(p);
		}

		private void Image_MouseDown_1(object sender, MouseButtonEventArgs e) {
			//string sqlbase = @"INSERT INTO institutions VALUES (NULL, ""{0}"", ( SELECT ID FROM types WHERE kind = ""{1}"" ), ""{2}"", ""{3}"");";
			string sqlBase = @"CALL insert_inst (""{0}"", ""{1}"", ""{2}"", ""{3}""); ";
			// TITLE, KIND, ADDRESS, PHONE

			if (textBox_Title.Text.Length != 0 &&
				textBox_Address.Text.Length != 0 &&
				textBox_Phone.Text.Length != 0 &&
				comboBox.SelectedIndex != -1) {
				string title = textBox_Title.Text;
				string address = textBox_Address.Text;
				string phone = textBox_Phone.Text;

				string kind = comboBox.SelectedItem.ToString();


				string sqlMain = String.Format(sqlBase, title, kind, address, phone);

				Connection conn;
				conn = Connection.GetConnection("");


				if (conn.NonQuery(sqlMain) == 0)
					MessageBox.Show("error");
			}
		}
	}
}
