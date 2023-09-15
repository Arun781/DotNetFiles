using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineMedicineStore.Models
{
	public class MedicineModel
	{
		internal int M_id { get; set; }
		public string MedicineCode { get; set; }
		public string MedicineName { get; set; }
		public string DiseaseName { get; set; }
		public string Company { get; set; }
		public float Price { get; set; }
	}
}