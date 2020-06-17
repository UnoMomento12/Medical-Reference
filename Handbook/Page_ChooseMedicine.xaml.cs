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
	/// Логика взаимодействия для Page_ChooseMedicine.xaml
	/// </summary>
	public partial class Page_ChooseMedicine : Page {
		public Page_ChooseMedicine() {
			InitializeComponent();

			LoadData();
		}

		private void Image_MouseDown(object sender, MouseButtonEventArgs e) {
			Page_MainWindow p = new Page_MainWindow();
			NavigationService.Navigate(p);
		}

		private void LoadData() {
			string sql = @"SELECT title FROM medicine";

			Connection conn;
			conn = Connection.GetConnection("");

			DataSet ds = new DataSet();
			ds = conn.SelecteQuery(sql);

			foreach(DataRow row in ds.Tables[0].Rows) {
				list.Items.Add(row[0]);
			}
 		}

		private void list_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			Page_Medicine p = new Page_Medicine(list.SelectedItem.ToString());
			NavigationService.Navigate(p);
		}
	}
}
