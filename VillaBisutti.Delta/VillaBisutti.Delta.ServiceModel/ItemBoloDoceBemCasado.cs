using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.ItemBoloDoceBemCasado
{
	[Route("/itembolos/{Id}", "GET")]
	public class Get : IReturn<model.ItemBoloDoceBemCasado>
	{
		public int Id { get; set; }
	}
	[Route("/itembolos", "GET")]
	public class GetAll : IReturn<List<model.ItemBoloDoceBemCasado>> { }
	[Route("/itembolos", "POST")]
	public class New
	{
		public model.ItemBoloDoceBemCasado entity { get; set; }
	}
	[Route("/itembolos", "PUT")]
	public class Update
	{
		public model.ItemBoloDoceBemCasado entity { get; set; }
	}
	[Route("/itembolos/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
