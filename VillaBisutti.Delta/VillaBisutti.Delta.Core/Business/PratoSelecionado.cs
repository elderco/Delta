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
			foreach (Model.Cardapio cardapio in Util.context.Cardapio.Include(c => c.Pratos).ToList())
				foreach (Model.TipoServico tipoServico in Util.context.TipoServico.ToList())
					foreach (Model.Prato prato in cardapio.Pratos)
						Util.context.PratoSelecionado.Add(new Model.PratoSelecionado
						{
							PratoId = prato.Id,
							CardapioId = cardapio.Id,
							TipoServico = tipoServico,
							Degustar = false,
							Escolhido = false,
							Rejeitado = false
						});
		}
		public void ImportarPratosDosCardapiosFaltantes(int cardapioId, int tipoServicoId)
		{
			IEnumerable<Model.PratoSelecionado> pratos = Util.context.PratoSelecionado.Where(ps => ps.CardapioId == cardapioId && ps.TipoServicoId == tipoServicoId && ps.EventoId == null);
			foreach (Model.Prato prato in Util.context.Cardapio.Include(c => c.Pratos).FirstOrDefault(c => c.Id == cardapioId).Pratos)
				if (pratos.Where(p => p.PratoId == prato.Id).Count() <= 0)
					Util.context.PratoSelecionado.Add(new Model.PratoSelecionado
					{
						PratoId = prato.Id,
						CardapioId = cardapioId,
						TipoServicoId = tipoServicoId,
						Degustar = false,
						Escolhido = false,
						Rejeitado = false
					});
			Util.context.SaveChanges();
			Util.ResetContext();
		}
		public void ImportarPratosDosCardapios(int cardapioId, int tipoServicoId)
		{
			IEnumerable<Model.PratoSelecionado> pratos = Util.context.PratoSelecionado.Where(ps => ps.CardapioId == cardapioId && ps.TipoServicoId == tipoServicoId && ps.EventoId == null);
			Util.context.PratoSelecionado.RemoveRange(pratos);
			Util.context.SaveChanges();
			Util.ResetContext();
			pratos = Util.context.PratoSelecionado.Where(ps => ps.CardapioId == cardapioId && ps.TipoServicoId == tipoServicoId && ps.EventoId == null);
			foreach (Model.Prato prato in Util.context.Prato.Include(p => p.Cardapios).Where(p => p.Cardapios.Where(c => c.Id == cardapioId).Count() > 0).ToList())
				if (pratos.Where(p => p.PratoId == prato.Id).Count() <= 0)
					Util.context.PratoSelecionado.Add(new Model.PratoSelecionado
					{
						PratoId = prato.Id,
						CardapioId = cardapioId,
						TipoServicoId = tipoServicoId,
						Degustar = false,
						Escolhido = false,
						Rejeitado = false
					});
			Util.context.SaveChanges();
			Util.ResetContext();
		}
		public Model.PratoSelecionado RejeitarPrato(int id)
		{
			Model.PratoSelecionado prato = Util.context.PratoSelecionado.Include(p => p.Prato).FirstOrDefault(p => p.Id == id);
			prato.Rejeitado = !prato.Rejeitado;
			new Data.PratoSelecionado().Update(prato);
			Util.context.SaveChanges();
			return prato;
		}
		public Model.PratoSelecionado DegustarPrato(int id)
		{
			Model.PratoSelecionado prato = Util.context.PratoSelecionado.Include(p => p.Prato).FirstOrDefault(p => p.Id == id);
			prato.Degustar = !prato.Degustar;
			new Data.PratoSelecionado().Update(prato);
			Util.context.SaveChanges();
			return prato;
		}
		public Model.PratoSelecionado EscolherPrato(int id)
		{
			Model.PratoSelecionado prato = Util.context.PratoSelecionado.Include(p => p.Prato).FirstOrDefault(p => p.Id == id);
			int quantosEscolhidos = Util.context.PratoSelecionado.Where(p =>
				p.Prato.TipoPratoId == prato.Prato.TipoPratoId
				&& p.EventoId == prato.EventoId
				&& p.Escolhido
				).Count();
			int quantosPode = Util.context.TipoPratoPadrao.FirstOrDefault(tpp => tpp.TipoPratoId == prato.Prato.TipoPratoId && tpp.EventoId == prato.EventoId).QuantidadePratos;
			if (quantosEscolhidos >= quantosPode && prato.Escolhido == false)
				return null;
			prato.Escolhido = !prato.Escolhido;
			new Data.PratoSelecionado().Update(prato);
			Util.context.SaveChanges();
			return prato;
		}
	}
}
