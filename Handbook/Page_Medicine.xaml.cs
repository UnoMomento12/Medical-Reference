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
	/// Логика взаимодействия для Page_Medicine.xaml
	/// </summary>
	public partial class Page_Medicine : Page {
		public Page_Medicine(string medicine) {
			InitializeComponent();
			textBlock_Title.Text = medicine;
			LoadData(medicine);
		}

		private void Image_MouseDown(object sender, MouseButtonEventArgs e) {
			Page_MainWindow p = new Page_MainWindow();
			NavigationService.Navigate(p);
		}

		private void LoadData(string medicine) {
			string sql = @"SELECT * FROM medicine_union WHERE title = """ + medicine + @"""; ";

			Connection conn;
			conn = Connection.GetConnection("");

			DataSet ds = new DataSet();
			ds = conn.SelecteQuery(sql);

			string result = "Назва: " + ds.Tables[0].Rows[0][1] + "\n\n" +
				"Основні фізико-хімічні властивості: " + ds.Tables[0].Rows[0][2] + "\n\n" +
				"Склад: " + ds.Tables[0].Rows[0][3] + "\n\n" +
				"Форма випуску: " + ds.Tables[0].Rows[0][4] + "\n\n" +
				"Фармакотерапевтична група: " + ds.Tables[0].Rows[0][5] + "\n\n" +
				"Фармакологічні властивості: " + ds.Tables[0].Rows[0][6] + "\n\n" +
				"Показання для застосування: " + ds.Tables[0].Rows[0][7] + "\n\n" +
				"Спосіб застосування та дози: " + ds.Tables[0].Rows[0][8] + "\n\n" +
				"Побічна дія: " + ds.Tables[0].Rows[0][9] + "\n\n" +
				"Протипоказання: " + ds.Tables[0].Rows[0][10] + "\n\n" +
				"Передозування: " + ds.Tables[0].Rows[0][11] + "\n\n" +
				"Особливості застосування: " + ds.Tables[0].Rows[0][12] + "\n\n" +
				"ВАРТІСТЬ - " + ds.Tables[0].Rows[0][13] + " грн.";

			textBlock_MainText.Text = result;
		}
	}
}
