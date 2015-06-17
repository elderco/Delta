using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.ItemFotoVideo
{
	[Route("/itemfotovideos/{Id}", "GET")]
	public class Get : IReturn<model.ItemFotoVideo>
	{
		public int Id { get; set; }
	}
	[Route("/itemfotovideos", "GET")]
	public class GetAll : IReturn<List<model.ItemFotoVideo>> { }
	[Route("/itemfotovideos", "POST")]
	public class New
	{
		public model.ItemFotoVideo entity { get; set; }
	}
	[Route("/itemfotovideos", "PUT")]
	public class Update
	{
		public model.ItemFotoVideo entity { get; set; }
	}
	[Route("/itemfotovideos/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
