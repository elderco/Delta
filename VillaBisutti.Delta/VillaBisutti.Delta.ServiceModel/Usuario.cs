using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.Usuario
{
	[Route("/usuarios/{Id}", "GET")]
	public class Get : IReturn<model.Usuario>
	{
		public int Id { get; set; }
	}
	[Route("/usuarios", "GET")]
	public class GetAll : IReturn<List<model.Usuario>> { }
	[Route("/usuarios", "POST")]
	public class New
	{
		public model.Usuario entity { get; set; }
	}
	[Route("/usuarios", "PUT")]
	public class Update
	{
		public model.Usuario entity { get; set; }
	}
	[Route("/usuarios/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
