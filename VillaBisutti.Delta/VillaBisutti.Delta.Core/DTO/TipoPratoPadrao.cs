using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace VillaBisutti.Delta.Core.DTO
{
	public class TipoPratoPadrao
	{
		public Dictionary<Model.Cardapio, List<Model.TipoPratoPadrao>> Itens { get; set; }
		public TipoPratoPadrao()
		{
			Data.Context context = new Data.Context();
			List<Model.TipoPratoPadrao> tiposPrato = context.TipoPratoPadrao.Include(tp => tp.TipoPrato).OrderBy(tp => tp.TipoServico).ToList();
			foreach (Model.Cardapio cardapio in context.Cardapio.OrderBy(c => c.Nome))
				Itens[cardapio] = tiposPrato.Where(tp => tp.CardapioId == cardapio.Id).ToList();
		}
	}
}
