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
	/// Логика взаимодействия для Page_ChooseMedicineCost.xaml
	/// </summary>
	public partial class Page_ChooseMedicineCost : Page {
		public Page_ChooseMedicineCost() {
			InitializeComponent();

			LoadData();
		}

		private void Image_MouseDown(object sender, MouseButtonEventArgs e) {
			Page_AdminPanel p = new Page_AdminPanel();
			NavigationService.Navigate(p);
		}

		private void LoadData() {
			string sql = @"SELECT * FROM medicine;";

			Connection conn;
			conn = Connection.GetConnection("");

			DataSet ds = new DataSet();
			ds = conn.SelecteQuery(sql);

			foreach (DataRow row in ds.Tables[0].Rows) {
				list.Items.Add(new MedicineCost(row[1].ToString(), row[13].ToString()));
			}

		}

		private void list_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			MedicineCost mc = (MedicineCost) list.SelectedItem;

			string title = mc.Title;

			Page_MedicineCost p = new Page_MedicineCost(title);
			NavigationService.Navigate(p);
		}
	}
}
