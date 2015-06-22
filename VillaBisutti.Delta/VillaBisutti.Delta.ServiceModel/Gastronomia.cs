using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.Gastronomia
{
	[Route("/gastronomia/{Id}", "GET")]
	public class Get : IReturn<model.ItemGastronomiaSelecionado>
	{
		public int Id { get; set; }
	}
	[Route("/gastronomia", "GET")]
	public class GetAll : IReturn<List<model.ItemGastronomiaSelecionado>> { }
	[Route("/gastronomia", "POST")]
	public class New
	{
		public model.ItemGastronomiaSelecionado entity { get; set; }
	}
	[Route("/gastronomia", "PUT")]
	public class Update
	{
		public model.ItemGastronomiaSelecionado entity { get; set; }
	}
	[Route("/gastronomia/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
