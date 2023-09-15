using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
//using System.Net.Http;
using System.Web.Http;
using OnlineMedicineStore20thAug.Models;

namespace OnlineMedicineStore20thAug.Controllers
{
	public class ValuesController : ApiController,MedicineModelAPI
	{
		public List<MedicineModel> medicines = new List<MedicineModel>();

		private int next_id = 1;

		public ValuesController()
		{
			PostAdd(new MedicineModel { M_id = 1, MedicineName = "Levocetrizine", MedicineCode = "F1003", Company = "Cipla", Price = 350, DiseaseName = null });

			PostAdd(new MedicineModel { M_id = 2, MedicineName = "cheston cold", MedicineCode = "F100325", Company = "Cipla", Price = 320, DiseaseName = null });
		}
		public void Delete(int id)
		{
			medicines.Find(m => m.M_id == id);
		}

		public IEnumerable<MedicineModel> GetAllMedicines()
		{
			return medicines;
		}

		public void GetMedicinById(int id)
		{
			medicines.Find(a => a.M_id == id);
		}

		public MedicineModel PostAdd(MedicineModel med)
		{
			if (med == null) { throw new ArgumentNullException("Hello"); }
			med.M_id = next_id++;
			medicines.Add(med);
			return med;
		}


		public bool PutMed(MedicineModel objmed)
		{
			if (objmed == null)
			{
				throw new ArgumentNullException("Hi");
			}
			int v = medicines.FindIndex(kil => kil.M_id <= objmed.M_id);
			if (v == -1) return false;
			else
			{
				medicines.RemoveAt(v);
				medicines.Add(objmed);
				return true;
			}
		}
	}
}
