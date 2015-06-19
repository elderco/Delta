using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.Evento
{
	[Route("/eventos/{Id}", "GET")]
	public class Get : IReturn<model.Evento>
	{
		public int Id { get; set; }
	}
	[Route("/eventos", "GET")]
	public class GetAll : IReturn<List<model.Evento>> { }
	[Route("/eventos", "POST")]
	public class New
	{
		public model.Evento entity { get; set; }
	}
	[Route("/eventos", "PUT")]
	public class Update
	{
		public model.Evento entity { get; set; }
	}
	[Route("/eventos/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
	/*
	 * classe de envio de dados:
	 * id da casa (local)
	 * id do produtor
	 * 
	 * classe de tráfego de dados
	 * id do evento
	 * data do evento
	 * nome dos homenageados
	 * tipo de evento
	*/
}
