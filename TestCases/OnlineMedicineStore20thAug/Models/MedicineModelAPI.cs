using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMedicineStore20thAug.Models
{
	public interface MedicineModelAPI
	{
		IEnumerable<MedicineModel> GetAllMedicines();
		void GetMedicinById(int id);
		MedicineModel PostAdd(MedicineModel med);
		void Delete(int id);
		bool PutMed(MedicineModel objmed);
	}
}
