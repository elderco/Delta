using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.DTO
{
	public class PratoSelecionado
	{
		public Dictionary<Model.TipoPrato, List<Model.PratoSelecionado>> Itens { get; set; }
		public PratoSelecionado() { }
		public PratoSelecionado(int cardapioId, int tipoServicoId)
		{
			Itens = new Dictionary<Model.TipoPrato, List<Model.PratoSelecionado>>();
			Data.Context context = new Data.Context();
			IQueryable<Model.TipoPrato> tiposDePrato = context.TipoPrato.Include(tp => tp.Pratos).Where(tp => tp.Pratos.Where(p => p.Cardapios.Where(c => c.Id == cardapioId).Count() > 0).Count() > 0);
			IQueryable<Model.PratoSelecionado> pratos = context.PratoSelecionado
				.Include(ps => ps.Prato).Include(ps => ps.Cardapio).Include(ps => ps.TipoServico);
			foreach (Model.TipoPrato tp in tiposDePrato)
			{
				Itens[tp] = pratos.Where(p => p.CardapioId == cardapioId && p.TipoServicoId == tipoServicoId).ToList();
			}
		}
	}
}
