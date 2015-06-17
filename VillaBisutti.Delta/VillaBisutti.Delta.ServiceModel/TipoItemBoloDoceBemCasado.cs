using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.TipoItemBoloDoceBemCasado
{
	[Route("/tipoitembolos/{Id}", "GET")]
	public class Get : IReturn<model.TipoItemBoloDoceBemCasado>
	{
		public int Id { get; set; }
	}
	[Route("/tipoitembolos", "GET")]
	public class GetAll : IReturn<List<model.TipoItemBoloDoceBemCasado>> { }
	[Route("/tipoitembolos", "POST")]
	public class New
	{
		public model.TipoItemBoloDoceBemCasado entity { get; set; }
	}
	[Route("/tipoitembolos", "PUT")]
	public class Update
	{
		public model.TipoItemBoloDoceBemCasado entity { get; set; }
	}
	[Route("/tipoitembolos/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
