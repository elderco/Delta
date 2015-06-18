using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class TipoItemDecoracao : IEntityBase
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public List<ItemDecoracao> Itens { get; set; }
	}
}
