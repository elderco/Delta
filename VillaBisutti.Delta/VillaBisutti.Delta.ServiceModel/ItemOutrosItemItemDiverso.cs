using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.ItemOutrosItemItemDiverso
{
	[Route("/itemdiversos/{Id}", "GET")]
	public class Get : IReturn<model.ItemOutroItemItemDiverso>
	{
		public int Id { get; set; }
	}
	[Route("/itemdiversos", "GET")]
	public class GetAll : IReturn<List<model.ItemOutroItemItemDiverso>> { }
	[Route("/itemdiversos", "POST")]
	public class New
	{
		public model.ItemOutroItemItemDiverso entity { get; set; }
	}
	[Route("/itemdiversos", "PUT")]
	public class Update
	{
		public model.ItemOutroItemItemDiverso entity { get; set; }
	}
	[Route("/itemdiversos/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
