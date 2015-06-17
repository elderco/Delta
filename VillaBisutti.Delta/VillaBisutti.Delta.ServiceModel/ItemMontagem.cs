using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.ItemMontagem
{
	[Route("/itemmontagens/{Id}", "GET")]
	public class Get : IReturn<model.ItemMontagem>
	{
		public int Id { get; set; }
	}
	[Route("/itemmontagens", "GET")]
	public class GetAll : IReturn<List<model.ItemMontagem>> { }
	[Route("/itemmontagens", "POST")]
	public class New
	{
		public model.ItemMontagem entity { get; set; }
	}
	[Route("/itemmontagens", "PUT")]
	public class Update
	{
		public model.ItemMontagem entity { get; set; }
	}
	[Route("/itemmontagens/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
