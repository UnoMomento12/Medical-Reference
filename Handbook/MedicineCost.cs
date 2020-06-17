using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handbook {
	class MedicineCost {
		//Изменение
		private string title;
		private string cost;
		public MedicineCost(string _title, string _cost) {
			title = _title;
			cost = _cost;
		}

		public string Title {
			get { return title; }
			set { title = value; }
		}

		public string Cost {
			get { return cost + " грн."; }
			set { cost = value; }
		}
	}
}
