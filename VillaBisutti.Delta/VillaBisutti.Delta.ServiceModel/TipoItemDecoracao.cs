using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.TipoItemDecoracao
{
	[Route("/tipoitemdecoracoes/{Id}", "GET")]
	public class Get : IReturn<model.TipoItemDecoracao>
	{
		public int Id { get; set; }
	}
	[Route("/tipoitemdecoracoes", "GET")]
	public class GetAll : IReturn<List<model.TipoItemDecoracao>> { }
	[Route("/tipoitemdecoracoes", "POST")]
	public class New
	{
		public model.TipoItemDecoracao entity { get; set; }
	}
	[Route("/tipoitemdecoracoes", "PUT")]
	public class Update
	{
		public model.TipoItemDecoracao entity { get; set; }
	}
	[Route("/tipoitemdecoracoes/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
