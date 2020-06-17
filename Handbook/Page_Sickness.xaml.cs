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
	/// Логика взаимодействия для Page_Sickness.xaml
	/// </summary>
	public partial class Page_Sickness : Page {
		public Page_Sickness(string sickness) {
			InitializeComponent();
			textBlock_Title.Text = sickness;
			LoadData(sickness);
		}

		private void Image_MouseDown(object sender, MouseButtonEventArgs e) {
			Page_MainWindow p = new Page_MainWindow();
			NavigationService.Navigate(p);
		}

		private void LoadData(string sickness) {
			string sql = @"SELECT * FROM sickness WHERE title = """ + sickness + @""";";

			Connection conn;
			conn = Connection.GetConnection("");

			DataSet ds = new DataSet();
			ds = conn.SelecteQuery(sql);

			string result = "\n" +
				"Короткий опис: " + ds.Tables[0].Rows[0][2] +
				"\n\nСимптоми: " + ds.Tables[0].Rows[0][3] +
				"\n\nЛікування: " + ds.Tables[0].Rows[0][4];

			textBlock_MainText.Text = result;

			sql = @"SELECT sym.title FROM sickness as s JOIN symptom_has_sickness  as ss ON s.ID = ss.sickness_ID JOIN symptom as sym ON ss.symptom_ID = sym.ID WHERE s.title = ""{0}"";";

			sql = String.Format(sql, sickness);

			ds = new DataSet();
			ds = conn.SelecteQuery(sql);

			if (HasRows(ds)) {
				string refSymptom = "\n\nПри яких симптомах виникає - \"" + sickness + "\":\n";
				foreach (DataRow row in ds.Tables[0].Rows) {
					refSymptom += "- " + row[0] + "\n";
				}
				textBlock_ReferencesSymptom.Text = refSymptom;
			}
		}

		private bool HasRows(DataSet ds) {
			if (ds.Tables[0].Rows.Count > 0)
				return true;
			return false;
		}
	}
}
