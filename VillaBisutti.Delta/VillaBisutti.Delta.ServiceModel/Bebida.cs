using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.Bebida
{
	[Route("/bebidas/{Id}", "GET")]
	public class Get : IReturn<model.ItemBebidaSelecionado>
	{
		public int Id { get; set; }
	}
	[Route("/bebidas", "GET")]
	public class GetAll : IReturn<List<model.ItemBebidaSelecionado>> { }
	[Route("/bebidas", "POST")]
	public class New
	{
		public model.ItemBebidaSelecionado entity { get; set; }
	}
	[Route("/bebidas", "PUT")]
	public class Update
	{
		public model.ItemBebidaSelecionado entity { get; set; }
	}
	[Route("/bebidas/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
