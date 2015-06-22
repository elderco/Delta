using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.TipoItemBebida
{
		[Route("/tipoitembebidas/{Id}", "GET")]
	public class Get : IReturn<model.TipoItemBebida>
	{
		public int Id { get; set; }
	}
	[Route("/tipoitembebidas", "GET")]
	public class GetAll : IReturn<List<model.TipoItemBebida>> { }
	[Route("/tipoitembebidas", "POST")]
	public class New
	{
		public model.TipoItemBebida entity { get; set; }
	}
	[Route("/tipoitembebidas", "PUT")]
	public class Update
	{
		public model.TipoItemBebida entity { get; set; }
	}
	[Route("/tipoitembebidas/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
