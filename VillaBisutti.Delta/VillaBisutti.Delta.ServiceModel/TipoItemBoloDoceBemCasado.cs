using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.TipoItemBoloDoceBemCasado
{
	[Route("/tipo-item-bolos-doce-bem-casado/{Id}", "GET")]
	public class Get : IReturn<model.TipoItemBoloDoceBemCasado>
	{
		public int Id { get; set; }
	}
	[Route("/tipo-item-bolos-doce-bem-casado", "GET")]
	public class GetAll : IReturn<List<model.TipoItemBoloDoceBemCasado>> { }
	[Route("/tipo-item-bolos-doce-bem-casado", "POST")]
	public class New
	{
		public model.TipoItemBoloDoceBemCasado entity { get; set; }
	}
	[Route("/tipo-item-bolos-doce-bem-casado", "PUT")]
	public class Update
	{
		public model.TipoItemBoloDoceBemCasado entity { get; set; }
	}
	[Route("/tipo-item-bolos-doce-bem-casado/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
