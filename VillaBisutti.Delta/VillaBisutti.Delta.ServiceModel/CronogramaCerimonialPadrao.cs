using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.CronogramaCerimonialPadrao
{
	[Route("/cerimonial-padrao/{Id}", "GET")]
	public class Get : IReturn<model.CronogramaCerimonialPadrao>
	{
		public int Id { get; set; }
	}
	[Route("/cerimonial-padrao", "GET")]
	public class GetAll : IReturn<List<model.CronogramaCerimonialPadrao>> { }
	[Route("/cerimonial-padrao", "POST")]
	public class New
	{
		public model.CronogramaCerimonialPadrao entity { get; set; }
	}
	[Route("/cerimonial-padrao", "PUT")]
	public class Update
	{
		public model.CronogramaCerimonialPadrao entity { get; set; }
	}
	[Route("/cerimonial-padrao/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
