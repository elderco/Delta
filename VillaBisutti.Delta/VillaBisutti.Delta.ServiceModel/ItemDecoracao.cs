using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.ItemDecoracao
{
	[Route("/itemdecoracoes/{Id}", "GET")]
	public class Get : IReturn<model.ItemDecoracao>
	{
		public int Id { get; set; }
	}
	[Route("/itemdecoracoes", "GET")]
	public class GetAll : IReturn<List<model.ItemDecoracao>> { }
	[Route("/itemdecoracoes", "POST")]
	public class New
	{
		public model.ItemDecoracao entity { get; set; }
	}
	[Route("/itemdecoracoes", "PUT")]
	public class Update
	{
		public model.ItemDecoracao entity { get; set; }
	}
	[Route("/itemdecoracoes/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
