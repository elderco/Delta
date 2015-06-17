using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.CronogramaCerimonial
{
	[Route("/cronogramascerimonial/{Id}", "GET")]
	public class Get : IReturn<model.CronogramaCerimonial>
	{
		public int Id { get; set; }
	}
	[Route("/cronogramascerimonial", "GET")]
	public class GetAll : IReturn<List<model.CronogramaCerimonial>> { }
	[Route("/cronogramascerimonial", "POST")]
	public class New
	{
		public model.CronogramaCerimonial entity { get; set; }
	}
	[Route("/cronogramascerimonial", "PUT")]
	public class Update
	{
		public model.CronogramaCerimonial entity { get; set; }
	}
	[Route("/cronogramascerimonial/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
