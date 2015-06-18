using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.Gastronomia
{
	[Route("/gastronomias/{Id}", "GET")]
	public class Get : IReturn<model.ItemGastronomiaSelecionado>
	{
		public int Id { get; set; }
	}
	[Route("/gastronomias", "GET")]
	public class GetAll : IReturn<List<model.ItemGastronomiaSelecionado>> { }
	[Route("/gastronomias", "POST")]
	public class New
	{
		public model.ItemGastronomiaSelecionado entity { get; set; }
	}
	[Route("/gastronomias", "PUT")]
	public class Update
	{
		public model.ItemGastronomiaSelecionado entity { get; set; }
	}
	[Route("/gastronomias/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
