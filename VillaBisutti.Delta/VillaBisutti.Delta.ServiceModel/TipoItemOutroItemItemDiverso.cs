using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.TipoItemOutroItemItemDiverso
{
	[Route("/tipoitemoutroItemitemdiversos/{Id}", "GET")]
	public class Get : IReturn<model.TipoItemOutroItemItemDiverso>
	{
		public int Id { get; set; }
	}
	[Route("/tipoitemoutroItemitemdiversos", "GET")]
	public class GetAll : IReturn<List<model.TipoItemOutroItemItemDiverso>> { }
	[Route("/tipoitemoutroItemitemdiversos", "POST")]
	public class New
	{
		public model.TipoItemOutroItemItemDiverso entity { get; set; }
	}
	[Route("/tipoitemoutroItemitemdiversos", "PUT")]
	public class Update
	{
		public model.TipoItemOutroItemItemDiverso entity { get; set; }
	}
	[Route("/tipoitemoutroItemitemdiversos/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
