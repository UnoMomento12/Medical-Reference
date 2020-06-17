using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
	/// Логика взаимодействия для Page_Symptom.xaml
	/// </summary>
	public partial class Page_Symptom : Page {
		public Page_Symptom(string symptom) {
			InitializeComponent();
			textBlock_Title.Text = symptom;
			LoadData(symptom);
		}

		private void Image_MouseDown(object sender, MouseButtonEventArgs e) {
			Page_MainWindow p = new Page_MainWindow();
			NavigationService.Navigate(p);
		}

		private void LoadData(string symptom) {
			string sql = @"SELECT * FROM symptom WHERE title = """ + symptom + @""";";

			Connection conn;
			conn = Connection.GetConnection("");

			DataSet ds = new DataSet();
			ds = conn.SelecteQuery(sql);

			string result = ds.Tables[0].Rows[0][2].ToString();


			textBlock_MainText.Text = result;


			// * * * * SICKNESS
			string sqlBase = @"SELECT ness.title FROM symptom as s INNER JOIN symptom_has_sickness as ss ON s.ID = ss.symptom_ID INNER JOIN sickness as ness ON ness.ID = ss.sickness_ID WHERE s.title = ""{0}"";";
			sql = String.Format(sqlBase, symptom);

			ds = new DataSet();
			ds = conn.SelecteQuery(sql);

			string resultSickness = "\n\n\n";

			if (HasRows(ds)) {
				resultSickness += "При яких захворювань виникає симптом - \"" + symptom + "\":\n";
				foreach (DataRow row in ds.Tables[0].Rows) {
					resultSickness += row[0].ToString() + "\n";
				}

				textBlock_ReferencSickness.Text = resultSickness;
			}


			// * * * * DOCTOR
			sqlBase = @"SELECT doc.specialty FROM symptom as s INNER JOIN symptom_has_doctor as sd ON s.ID = sd.symptom_ID INNER JOIN doctor as doc ON doc.ID = sd.doctor_ID WHERE s.title = ""{0}"";";
			sql = String.Format(sqlBase, symptom);

			ds = new DataSet();
			ds = conn.SelecteQuery(sql);

			string resultDoctor = "\n\n";

			if (HasRows(ds)) {
				resultDoctor += "При яких захворюваннях виникають - " + symptom + ":\n";
				foreach (DataRow row in ds.Tables[0].Rows) {
					resultDoctor += row[0].ToString() + "\n";
				}

				textBlock_ReferencDoctor.Text = resultDoctor;
			}

			

			// * * * * MEDICINE
			sqlBase = @"SELECT med.title FROM symptom as s INNER JOIN symptom_has_medicine as sm ON s.ID = sm.symptom_ID INNER JOIN medicine as med ON med.ID = sm.medicine_ID WHERE s.title = ""{0}"";";
			sql = String.Format(sqlBase, symptom);

			ds = new DataSet();
			ds = conn.SelecteQuery(sql);

			string resultMedicine = "\n\n";

			if (HasRows(ds)) {
				resultMedicine += "До яких лікарів звертатись, якщо виникають - " + symptom + ":\n";
				foreach (DataRow row in ds.Tables[0].Rows) {
					resultMedicine += row[0].ToString() + "\n";
				}

				textBlock_ReferencDoctor.Text = resultMedicine;
			}
		}

		private bool HasRows(DataSet ds) {
			if (ds.Tables[0].Rows.Count > 0)
				return true;
			return false;
		}
	}

		
}
