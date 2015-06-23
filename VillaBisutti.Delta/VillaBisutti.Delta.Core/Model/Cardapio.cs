using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class Cardapio : IEntityBase
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public List<Prato> Pratos { get; set; }
	}
}
