using System.Web.Http;
using WebActivatorEx;
using OnlineMedicineStore20thAug;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace OnlineMedicineStore20thAug
{
	public class SwaggerConfig
	{
		public static void Register()
		{
			var thisAssembly = typeof(SwaggerConfig).Assembly;
			GlobalConfiguration.Configuration
				.EnableSwagger(c =>
				   c.SingleApiVersion("v1", "OnlineMedicineStore20thAug"))
.EnableSwaggerUi();
		}
	}
}
