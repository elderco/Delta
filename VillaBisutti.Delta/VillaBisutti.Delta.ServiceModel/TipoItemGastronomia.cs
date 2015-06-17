using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.TipoItemGastronomia
{
	[Route("/tipoitemgastronomias/{Id}", "GET")]
	public class Get : IReturn<model.TipoItemGastronomia>
	{
		public int Id { get; set; }
	}
	[Route("/tipoitemgastronomias", "GET")]
	public class GetAll : IReturn<List<model.TipoItemGastronomia>> { }
	[Route("/tipoitemgastronomias", "POST")]
	public class New
	{
		public model.TipoItemGastronomia entity { get; set; }
	}
	[Route("/tipoitemgastronomias", "PUT")]
	public class Update
	{
		public model.TipoItemGastronomia entity { get; set; }
	}
	[Route("/tipoitemgastronomias/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
