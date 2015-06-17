using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.ItemSomIluminacao
{
	[Route("/itemsomiluminacoes/{Id}", "GET")]
	public class Get : IReturn<model.ItemSomIluminacao>
	{
		public int Id { get; set; }
	}
	[Route("/itemsomiluminacoes", "GET")]
	public class GetAll : IReturn<List<model.ItemSomIluminacao>> { }
	[Route("/itemsomiluminacoes", "POST")]
	public class New
	{
		public model.ItemSomIluminacao entity { get; set; }
	}
	[Route("/itemsomiluminacoes", "PUT")]
	public class Update
	{
		public model.ItemSomIluminacao entity { get; set; }
	}
	[Route("/itemsomiluminacoes/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
