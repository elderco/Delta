using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.TipoItemSomIluminacao
{
	[Route("/tipoitemsomiluminacoes/{Id}", "GET")]
	public class Get : IReturn<model.TipoItemSomIluminacao>
	{
		public int Id { get; set; }
	}
	[Route("/tipoitemsomiluminacoes", "GET")]
	public class GetAll : IReturn<List<model.TipoItemSomIluminacao>> { }
	[Route("/tipoitemsomiluminacoes", "POST")]
	public class New
	{
		public model.TipoItemSomIluminacao entity { get; set; }
	}
	[Route("/tipoitemsomiluminacoes", "PUT")]
	public class Update
	{
		public model.TipoItemSomIluminacao entity { get; set; }
	}
	[Route("/tipoitemsomiluminacoes/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
