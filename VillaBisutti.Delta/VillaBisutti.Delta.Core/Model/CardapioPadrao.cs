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
		public int TipoServicoId { get; set; }
		public TipoServico TipoServico {
			get
			{
				return (TipoServico)TipoServicoId;
			}
			set
			{
				TipoServicoId = (int)value;
			}
		}
		public List<Prato> PratosSelecionados { get; set; }
	}
}
