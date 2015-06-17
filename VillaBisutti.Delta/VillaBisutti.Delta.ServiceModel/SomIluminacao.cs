using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.SomIluminacao
{
	[Route("/somiluminacoes/{Id}", "GET")]
	public class Get : IReturn<model.SomIluminacao>
	{
		public int Id { get; set; }
	}
	[Route("/somiluminacoes", "GET")]
	public class GetAll : IReturn<List<model.SomIluminacao>> { }
	[Route("/somiluminacoes", "POST")]
	public class New
	{
		public model.SomIluminacao entity { get; set; }
	}
	[Route("/somiluminacoes", "PUT")]
	public class Update
	{
		public model.SomIluminacao entity { get; set; }
	}
	[Route("/somiluminacoes/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
