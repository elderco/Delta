using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VillaBisutti.Delta.Core.Model
{
	public class Prato : IEntityBase
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public int TipoPratoId { get; set; }
		public TipoPrato TipoPrato { get; set; }
		public List<Cardapio> Cardapios { get; set; }
	}
}
