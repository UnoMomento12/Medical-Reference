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
	/// Логика взаимодействия для Page_Institutions.xaml
	/// </summary>
	public partial class Page_Institutions : Page {
		public Page_Institutions() {
			InitializeComponent();

			LoadData("%%");
		}

		private void Image_MouseDown(object sender, MouseButtonEventArgs e) {
			Page_MainWindow p = new Page_MainWindow();
			NavigationService.Navigate(p);
		}
		/*
		private void LoadData() {
			string sql = @"SELECT i.ID, t.kind, i.title, i.address, i.phone FROM institutions as i JOIN types as t ON i.kind = t.ID;";

			Connection conn;
			conn = Connection.GetConnection("");

			DataSet ds = new DataSet();
			ds = conn.SelecteQuery(sql);

			MessageBox.Show(sql);

			string temp = "";
			foreach(DataRow row in ds.Tables[0].Rows) {
				temp = row[2] + " - " + row[3] + " - " + row[4];
				list.Items.Add(temp);
			}
 		}
		*/
		private void LoadData(string inst) {
			string sqlBase = @"SELECT i.ID, t.kind, i.title, i.address, i.phone FROM institutions as i JOIN types as t ON i.kind = t.ID WHERE t.kind LIKE ""{0}"";";

			Connection conn;
			conn = Connection.GetConnection("");

			string sql = String.Format(sqlBase, inst);

			DataSet ds = new DataSet();
			ds = conn.SelecteQuery(sql);

			list.Items.Clear();
			

			string temp = "";
			foreach (DataRow row in ds.Tables[0].Rows) {
				temp = row[2] + " - " + row[3] + " - " + row[4];
				list.Items.Add(temp);
			}
		}

		private void Filter_MouseDown(object sender, MouseButtonEventArgs e) {
			string name = ((TextBlock)sender).Name;

			switch (name) {
				case "textBlock_1":
					LoadData("Лікарня");
					break;

				case "textBlock_2":
					LoadData("Аптека");
					break;

				case "textBlock_3":
					LoadData("Диспансер");
					break;

				case "textBlock_4":
					LoadData("Поліклініка");
					break;

				case "textBlock_5":
					LoadData("Стоматологія");
					break;

				case "textBlock_6":
					LoadData("Медичний центр");
					break;

			}
		}
	}
}
