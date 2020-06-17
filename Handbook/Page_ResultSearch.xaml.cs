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
	/// Логика взаимодействия для Page_ResultSearch.xaml
	/// </summary>
	public partial class Page_ResultSearch : Page {
		private const int permissibleLength = 4;
		private const int permissibleLengthSyllable = 3;
		public Page_ResultSearch(string searchString) {
			InitializeComponent();
			textBlock_EmptyResult.Text = "";
			MainSearch(searchString);
		}

		private void Image_MouseDown(object sender, MouseButtonEventArgs e) {
			Page_MainWindow p = new Page_MainWindow();
			NavigationService.Navigate(p);
		}

		private void MainSearch(string searchString) {
			string[] arrayTables = {"symptom", "sickness", "institutions", "medicine"};
			DataSet[] arraySet = new DataSet[arrayTables.Length];

			for (int i=0; i < arrayTables.Length; i++) {
				arraySet[i] = new DataSet();
				arraySet[i] = Search(searchString, arrayTables[i]);
				arraySet[i].Tables[0].TableName = arrayTables[i];
			};

			
			for (int i=1; i<arraySet.Length; i++) {
				arraySet[0].Tables.Add(arraySet[i].Tables[0].Copy());
			}

			if (!IsEmpty(arraySet[0]))
				LoadData(arraySet[0]);
			else
				textBlock_EmptyResult.Text = "Пошук не дав ніякого результату :(";
			
		}

		private bool IsEmpty(DataSet ds) {
			foreach (DataTable table in ds.Tables) {
				if (table.Rows.Count > 0)
					return false;
			}
			return true;
		}


		private void LoadData(DataSet ds) {
			// Load data from ds in ListView
			ListViewItem item;

			foreach (DataTable table in ds.Tables) {
				foreach (DataRow row in table.Rows) {
					//if (NotConsist(row[1].ToString())) {
						item = new ListViewItem();
						item.Content = row[1].ToString();
						item.Tag = table.TableName;
						list.Items.Add(item);
					//}
				}
			}

		}


		private DataSet Search(string searchString, string table) {
			DataSet ds = new DataSet();

			string sqlBase = @"SELECT * FROM {0}
					WHERE title LIKE concat_str(""{1}"")
					OR title LIKE concat_str(SPLIT_STRING(""{1}"", 1))
					OR title LIKE concat_str(SPLIT_STRING(""{1}"", 2))
					OR title LIKE concat_str(SPLIT_STRING(""{1}"", 3))
					OR title LIKE concat_str(get_root(SPLIT_STRING(""{1}"", 1)))
					OR title LIKE concat_str(get_root(SPLIT_STRING(""{1}"", 2)))
					OR title LIKE concat_str(get_root(SPLIT_STRING(""{1}"", 3))); ";

			string sql = String.Format(sqlBase, table, searchString);

			Connection conn;
			conn = Connection.GetConnection("");

			ds = conn.SelecteQuery(sql);
			return ds;
		}

		private void list_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			ListViewItem item = (ListViewItem)list.SelectedItem;

			string title = item.Content.ToString();
			string table = item.Tag.ToString();
			
			switch (table) {
				case "symptom":
					Page_Symptom p1 = new Page_Symptom(title);
					NavigationService.Navigate(p1);
					break;
				case "sickness":
					Page_Sickness p2 = new Page_Sickness(title);
					NavigationService.Navigate(p2);
					break;
				case "institutions":
					Page_Institutions p3 = new Page_Institutions();
					NavigationService.Navigate(p3);
					break;
				case "medicine":
					Page_Medicine p4 = new Page_Medicine(title);
					NavigationService.Navigate(p4);
					break;
			}
		}
	}
}
