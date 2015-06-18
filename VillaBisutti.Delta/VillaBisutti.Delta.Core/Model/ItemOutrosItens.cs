using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class ItemOutrosItens : IEntityBase
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public int Quantidade { get; set; }
		public int TipoItemOutroItemItemDiversoId { get; set; }
		public TipoItemOutrosItens TipoItemOutroItemItemDiverso { get; set; }
	}
}
