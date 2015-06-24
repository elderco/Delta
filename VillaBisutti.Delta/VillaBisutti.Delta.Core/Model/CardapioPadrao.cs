using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Model
{
	public class CardapioPadrao : IEntityBase
	{
		public int Id { get; set; }
		public int CardapioId { get; set; }
		public Cardapio Cardapio { get; set; }
		public TipoServico TipoServico { get; set; }
		public List<Prato> PratosSelecionados { get; set; }
	}
}
