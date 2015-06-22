using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.PerfilUsuarioSistema
{
	[Route("/perfil-usuario-sistema/{Id}", "GET")]
	public class Get : IReturn<model.PerfilUsuarioSistema>
	{
		public int Id { get; set; }
	}
	[Route("/perfil-usuario-sistema", "GET")]
	public class GetAll : IReturn<List<model.PerfilUsuarioSistema>> { }
	[Route("/perfil-usuario-sistema", "POST")]
	public class New
	{
		public model.PerfilUsuarioSistema entity { get; set; }
	}
	[Route("/perfil-usuario-sistema", "PUT")]
	public class Update
	{
		public model.PerfilUsuarioSistema entity { get; set; }
	}
	[Route("/perfil-usuario-sistema/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
