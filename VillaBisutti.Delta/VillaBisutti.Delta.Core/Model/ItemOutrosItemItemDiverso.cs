using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class ItemOutrosItemItemDiverso : IEntityBase
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public int Quantidade { get; set; }
		public int ItemOutrosItemItemDiversoId { get; set; }
		public ItemOutrosItemItemDiverso ItemOutrosItemItemDiverso { get; set; }
	}
}
