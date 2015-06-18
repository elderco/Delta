using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.BoloDoceBemCasado
{
	[Route("/bolos/{Id}", "GET")]
	public class Get : IReturn<model.ItemBoloDoceBemCasadoSelecionado>
	{
		public int Id { get; set; }
	}
	[Route("/bolos", "GET")]
	public class GetAll : IReturn<List<model.ItemBoloDoceBemCasadoSelecionado>> { }
	[Route("/bolos", "POST")]
	public class New
	{
		public model.ItemBoloDoceBemCasadoSelecionado entity { get; set; }
	}
	[Route("/bolos", "PUT")]
	public class Update
	{
		public model.ItemBoloDoceBemCasadoSelecionado entity { get; set; }
	}
	[Route("/bolos/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
