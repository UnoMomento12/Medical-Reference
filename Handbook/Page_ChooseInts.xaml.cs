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
	/// Логика взаимодействия для Page_ChooseInts.xaml
	/// </summary>
	public partial class Page_ChooseInts : Page {
		public Page_ChooseInts() {
			InitializeComponent();

			LoadData();
		}

		private void Image_MouseDown(object sender, MouseButtonEventArgs e) {
			Page_AdminPanel p = new Page_AdminPanel();
			NavigationService.Navigate(p);
		}


		private void LoadData() {
			string sql = @"SELECT title FROM institutions;";

			Connection conn;
			conn = Connection.GetConnection("");

			DataSet ds = new DataSet();
			ds = conn.SelecteQuery(sql);

			foreach (DataRow row in ds.Tables[0].Rows) {
				list.Items.Add(row[0].ToString());
			}
		}

		private void list_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			Page_EditInst p = new Page_EditInst(list.SelectedItem.ToString());
			NavigationService.Navigate(p);
		}
	}
}
