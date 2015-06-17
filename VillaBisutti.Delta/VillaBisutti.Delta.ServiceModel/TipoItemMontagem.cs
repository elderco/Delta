using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.TipoItemMontagem
{
	[Route("/tipoitemmontagens/{Id}", "GET")]
	public class Get : IReturn<model.TipoItemMontagem>
	{
		public int Id { get; set; }
	}
	[Route("/tipoitemmontagens", "GET")]
	public class GetAll : IReturn<List<model.TipoItemMontagem>> { }
	[Route("/tipoitemmontagens", "POST")]
	public class New
	{
		public model.TipoItemMontagem entity { get; set; }
	}
	[Route("/tipoitemmontagens", "PUT")]
	public class Update
	{
		public model.TipoItemMontagem entity { get; set; }
	}
	[Route("/tipoitemmontagens/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
