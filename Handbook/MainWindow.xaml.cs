using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

namespace Handbook {
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();

			Connection conn;
			conn = Connection.GetConnection("Server=localhost; Database=handbook; UID=root; PWD=Art14051997;");
			 /*
			// - - HIDE ALL WINDOW
			Shell32.Shell s32 = new Shell32.Shell();
			s32.MinimizeAll();
			*/


			//Page_AdminPanel p1 = new Page_AdminPanel();
			Page_MainWindow p1 = new Page_MainWindow();
			frame.NavigationService.Navigate(p1);
			

		}


		public void Method() {
			Connection conn;
			conn = Connection.GetConnection("Server=localhost; Database=handbook; UID=root; PWD=Art14051997;");

			// SELECT

			DataSet ds = new DataSet();

			ds = conn.SelecteQuery("SELECT * FROM symptom;");
			DataRow dr = ds.Tables[0].Rows[0];
			MessageBox.Show(dr[2].ToString());

			string str = ds.Tables[0].Rows[0][2].ToString();
			MessageBox.Show(str);

			// INSERT, UPDATE, DELETE
/*
			string sql = @"INSERT INTO symptom VALUES (NULL, ""test"", ""test2TEXT"", 1);";
			conn.NonQuery(sql);

			string sql2 = @"DELETE FROM symptom WHERE ID=12;";
			conn.NonQuery(sql2);
			*/
		}
	}
}
