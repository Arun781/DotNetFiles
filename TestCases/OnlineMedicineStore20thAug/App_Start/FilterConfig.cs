using System.Web;
using System.Web.Mvc;

namespace OnlineMedicineStore20thAug
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
