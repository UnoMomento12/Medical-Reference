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
	/// Логика взаимодействия для Page_ChooseSymptom.xaml
	/// </summary>
	public partial class Page_ChooseSymptom : Page {
		public Page_ChooseSymptom(string organ) {
			InitializeComponent();

			

			textBlock_Name.Text = organ;

			LoadData(organ);
		}


		private void Image_MouseDown(object sender, MouseButtonEventArgs e) {
			Page_MainWindow p = new Page_MainWindow();
			NavigationService.Navigate(p);
		}

		private void LoadData(string organ) {
			string sql = @"SELECT title FROM symptom AS s JOIN part AS p ON s.ID_part = p.ID WHERE p.organ = """ + organ + @""";";

			Connection conn;
			conn = Connection.GetConnection("");

			DataSet ds = new DataSet();

			ds = conn.SelecteQuery(sql);
			
			foreach (DataRow row in ds.Tables[0].Rows) {
				list.Items.Add(row[0]);
			}


		}

		private void list_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			Page_Symptom p = new Page_Symptom(list.SelectedItem.ToString());
			NavigationService.Navigate(p);

		}
	}
}
