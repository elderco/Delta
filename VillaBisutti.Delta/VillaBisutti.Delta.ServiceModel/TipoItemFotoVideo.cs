using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.TipoItemFotoVideo
{
	[Route("/tipoitemfotovideos/{Id}", "GET")]
	public class Get : IReturn<model.TipoItemFotoVideo>
	{
		public int Id { get; set; }
	}
	[Route("/tipoitemfotovideos", "GET")]
	public class GetAll : IReturn<List<model.TipoItemFotoVideo>> { }
	[Route("/tipoitemfotovideos", "POST")]
	public class New
	{
		public model.TipoItemFotoVideo entity { get; set; }
	}
	[Route("/tipoitemfotovideos", "PUT")]
	public class Update
	{
		public model.TipoItemFotoVideo entity { get; set; }
	}
	[Route("/tipoitemfotovideos/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
