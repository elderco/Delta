using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.PerfilUsuarioSistema
{
	[Route("/perfilusuarios/{Id}", "GET")]
	public class Get : IReturn<model.PerfilUsuarioSistema>
	{
		public int Id { get; set; }
	}
	[Route("/perfilusuarios", "GET")]
	public class GetAll : IReturn<List<model.PerfilUsuarioSistema>> { }
	[Route("/perfilusuarios", "POST")]
	public class New
	{
		public model.PerfilUsuarioSistema entity { get; set; }
	}
	[Route("/perfilusuarios", "PUT")]
	public class Update
	{
		public model.PerfilUsuarioSistema entity { get; set; }
	}
	[Route("/perfilusuarios/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
