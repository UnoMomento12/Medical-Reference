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
using System.Data;

namespace Handbook {
	/// <summary>
	/// Логика взаимодействия для Page_EditInst.xaml
	/// </summary>
	public partial class Page_EditInst : Page {
		private string pastTitle;
		private TextBox focusTextBox;

		public Page_EditInst(string inst) {
			InitializeComponent();
			pastTitle = inst;
			focusTextBox = textBox_Title;
			LoadComboBox();
			LoadData(inst);
		}

	
		private void LoadComboBox() {
			string sql = @"SELECT kind FROM types;";

			Connection conn;
			conn = Connection.GetConnection("");

			DataSet ds = new DataSet();
			ds = conn.SelecteQuery(sql);

			foreach (DataRow row in ds.Tables[0].Rows) {
				comboBox.Items.Add(row[0]);
			}
		}

		private void LoadData(string inst) {
			string sql = String.Format(@"SELECT title, t.kind, address, phone FROM institutions as i JOIN types as t ON i.kind = t.ID WHERE title = ""{0}"";", inst);

			Connection conn;
			conn = Connection.GetConnection("");

			DataSet ds = new DataSet();
			ds = conn.SelecteQuery(sql);

			comboBox.SelectedItem = ds.Tables[0].Rows[0][1].ToString();

			textBox_Title.Text = ds.Tables[0].Rows[0][0].ToString();
			textBox_Address.Text = ds.Tables[0].Rows[0][2].ToString();
			textBox_Phone.Text = ds.Tables[0].Rows[0][3].ToString();
		}

		private void MouseDown_Save(object sender, MouseButtonEventArgs e) {
			//string sqlBase = @"UPDATE institutions SET title = ""{0}"", kind = {1}, address = ""{2}"", phone = ""{3}"" WHERE title = ""{4}"";";
			string sqlBase = @"CALL update_inst(""{0}"", {1}, ""{2}"", ""{3}"", ""{4}"");";

			string subSql = String.Format(@"SELECT ID FROM types WHERE kind = ""{0}""", comboBox.SelectedItem);

			Connection conn;
			conn = Connection.GetConnection("");

			DataSet d1 = new DataSet();
			d1 = conn.SelecteQuery(subSql);
			int kind = Convert.ToInt32(d1.Tables[0].Rows[0][0]);

			if (textBox_Title.Text.Length != 0 &&
				textBox_Address.Text.Length != 0 &&
				textBox_Phone.Text.Length != 0) {
				string newTitle = textBox_Title.Text;
				string newAddress = textBox_Address.Text;
				string newPhone = textBox_Phone.Text;

				string sqlMain = String.Format(sqlBase, newTitle, kind, newAddress, newPhone, pastTitle);

				if (conn.NonQuery(sqlMain) == 0)
					MessageBox.Show("Error");

				Page_AdminPanel p = new Page_AdminPanel();
				NavigationService.Navigate(p);
			}
		}

		public void SelectedTextBox(object sender, RoutedEventArgs e) {
			focusTextBox = (TextBox)sender;
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

		private void MouseDown_Delete(object sender, MouseButtonEventArgs e) {
			//string sql = String.Format(@"DELETE FROM institutions WHERE title = ""{0}""", pastTitle);
			string sql = String.Format(@"CALL delete_inst(""{0}"");", pastTitle);

			Connection conn;
			conn = Connection.GetConnection("");

			conn.NonQuery(sql);

			Page_AdminPanel p = new Page_AdminPanel();
			NavigationService.Navigate(p);
		}

		private void MouseDown_AdminPanel(object sender, MouseButtonEventArgs e) {
			Page_AdminPanel p = new Page_AdminPanel();
			NavigationService.Navigate(p);
		}
	}
}
