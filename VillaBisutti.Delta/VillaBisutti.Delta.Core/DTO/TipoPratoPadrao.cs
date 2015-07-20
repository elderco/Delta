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
		public Dictionary<Model.Cardapio, Dictionary<Model.TipoServico, List<Model.TipoPratoPadrao>>> Itens { get; set; }
		public TipoPratoPadrao()
		{
			Itens = new Dictionary<Model.Cardapio, Dictionary<Model.TipoServico, List<Model.TipoPratoPadrao>>>();
			Data.Context context = new Data.Context();
			List<Model.TipoPratoPadrao> tiposPrato = context.TipoPratoPadrao.Include(tp => tp.TipoPrato).OrderBy(tp => tp.TipoServico).ToList();
			foreach (Model.Cardapio cardapio in context.Cardapio.OrderBy(c => c.Nome))
			{
				Dictionary<Model.TipoServico, List<Model.TipoPratoPadrao>> lista = new Dictionary<Model.TipoServico, List<Model.TipoPratoPadrao>>();
				foreach(Model.TipoServico tipoServico in new Data.TipoServico().GetCollection(0))
				{
					lista[(Model.TipoServico)tipoServico] = tiposPrato.Where(tp => tp.CardapioId == cardapio.Id && tp.TipoServico == (Model.TipoServico)tipoServico).ToList();
				}
				Itens[cardapio] = lista;
			}
		}
	}
}
