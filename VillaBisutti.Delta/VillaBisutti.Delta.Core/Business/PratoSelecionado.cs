using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace VillaBisutti.Delta.Core.Business
{
	public class PratoSelecionado
	{
		public void ImportarPratosDosCardapios()
		{
			Data.Context context = new Data.Context();
			foreach (Model.Cardapio cardapio in context.Cardapio.Include(c => c.Pratos).ToList())
				foreach (Model.TipoServico tipoServico in new Data.TipoServico().GetCollection(0))
					foreach (Model.Prato prato in cardapio.Pratos)
						context.PratoSelecionado.Add(new Model.PratoSelecionado
						{
							PratoId = prato.Id,
							CardapioId = cardapio.Id,
							TipoServico = tipoServico,
							Degustar = true,
							Escolhido = false
						});
		}
		public void ImportarPratosDosCardapios(int cardapioId, int tipoServicoId)
		{
			Data.Context context = new Data.Context();
			IQueryable<Model.PratoSelecionado> pratos = context.PratoSelecionado.Where(ps => ps.CardapioId == cardapioId && ps.TipoServicoId == tipoServicoId && ps.EventoId == null);
			foreach (Model.Prato prato in context.Prato.Include(p => p.Cardapios).Where(p => p.Cardapios.Where(c => c.Id == cardapioId).Count() > 0).ToList())
				if (pratos.Where(p => p.PratoId == prato.Id).Count() <= 0)
					context.PratoSelecionado.Add(new Model.PratoSelecionado
					{
						PratoId = prato.Id,
						CardapioId = cardapioId,
						TipoServicoId = tipoServicoId,
						Degustar = true,
						Escolhido = false
					});
			context.SaveChanges();
			context.Dispose();
		}
	}
}
