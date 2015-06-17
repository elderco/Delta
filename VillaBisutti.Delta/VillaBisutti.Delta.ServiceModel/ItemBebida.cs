using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.ItemBebida
{
	[Route("/itembebidas/{Id}", "GET")]
	public class Get : IReturn<model.ItemBebida>
	{
		public int Id { get; set; }
	}
	[Route("/itembebidas", "GET")]
	public class GetAll : IReturn<List<model.ItemBebida>> { }
	[Route("/itembebidas", "POST")]
	public class New
	{
		public model.ItemBebida entity { get; set; }
	}
	[Route("/itembebidas", "PUT")]
	public class Update
	{
		public model.ItemBebida entity { get; set; }
	}
	[Route("/itembebidas/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
