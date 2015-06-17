using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.RoteiroPadrao
{
	[Route("/roteirospadroes/{Id}", "GET")]
	public class Get : IReturn<model.RoteiroPadrao>
	{
		public int Id { get; set; }
	}
	[Route("/roteirospadroes", "GET")]
	public class GetAll : IReturn<List<model.RoteiroPadrao>> { }
	[Route("/roteirospadroes", "POST")]
	public class New
	{
		public model.RoteiroPadrao entity { get; set; }
	}
	[Route("/roteirospadroes", "PUT")]
	public class Update
	{
		public model.RoteiroPadrao entity { get; set; }
	}
	[Route("/roteirospadroes/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
