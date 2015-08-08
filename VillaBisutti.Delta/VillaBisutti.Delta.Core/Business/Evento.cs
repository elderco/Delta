using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

namespace VillaBisutti.Delta.Core.Business
{
	public class Evento
	{
		public Data.Context context
		{
			get
			{
				return Util.context;
			}
		}
		public void CopiarRoteiroPadrao(Model.Evento evento)
		{
			if (evento.Roteiro == null)
				evento.Roteiro = new List<Model.ItemRoteiro>();
			foreach (Model.ItemRoteiro item in context.ItemRoteiro.Where(rp => rp.TipoEvento == evento.TipoEvento && (rp.EventoId == 0 || rp.EventoId == null)))
				context.ItemRoteiro.Add(new Model.ItemRoteiro
				{
					EventoId = evento.Id,
					Titulo = item.Titulo,
					HorarioInicio = evento.HorarioInicio + item.HorarioInicio,
					Observacao = item.Observacao
				});
			context.SaveChanges();
		}
		public void CopiarCerimonialPadrao(Model.Evento evento)
		{
			if (evento.Cerimonial == null)
				evento.Cerimonial = new List<Model.ItemCerimonial>();
			foreach (Model.ItemCerimonial item in context.ItemCerimonial.Where(rp => rp.TipoEvento == evento.TipoEvento && (rp.EventoId == 0 || rp.EventoId == null)))
				context.ItemCerimonial.Add(new Model.ItemCerimonial
				{
					EventoId = evento.Id,
					Titulo = item.Titulo,
					HorarioInicio = evento.HorarioInicio + item.HorarioInicio,
					Observacao = item.Observacao
				});
			context.SaveChanges();
		}
		public void CopiarCardapioPadrao(Model.Evento evento)
		{
			if (evento.CardapioId == 0 || evento.TipoServicoId == 0)
				return;
			if (evento.Gastronomia.Pratos == null)
				evento.Gastronomia.Pratos = new List<Model.PratoSelecionado>();
			if (evento.Gastronomia.TiposPratos == null)
				evento.Gastronomia.TiposPratos = new List<Model.TipoPratoPadrao>();
			List<Model.PratoSelecionado> pratos = context.PratoSelecionado.Where(ps => ps.EventoId == evento.Id).ToList();
			foreach (Model.PratoSelecionado prato in context.PratoSelecionado.Where(p => p.EventoId == null && p.CardapioId == evento.CardapioId && p.TipoServicoId == evento.TipoServicoId))
				if (pratos.Where(p => p.PratoId == prato.PratoId).Count() <= 0)
					context.PratoSelecionado.Add(new Model.PratoSelecionado
					{
						EventoId = evento.Id,
						PratoId = prato.PratoId,
						Degustar = prato.Degustar,
						Escolhido = false,
						Rejeitado = false

					});
			List<Model.TipoPratoPadrao> tipos = context.TipoPratoPadrao.Where(tps => tps.EventoId == evento.Id).ToList();
			foreach (Model.TipoPratoPadrao tipo in context.TipoPratoPadrao.Where(p => p.EventoId == null && p.CardapioId == evento.CardapioId && p.TipoServicoId == evento.TipoServicoId))
				if (tipos.Where(t => t.TipoPratoId == tipo.TipoPratoId).Count() <= 0)
					context.TipoPratoPadrao.Add(new Model.TipoPratoPadrao
					{
						EventoId = evento.Id,
						TipoPratoId = tipo.TipoPratoId,
						QuantidadePratos = tipo.QuantidadePratos
					});
			context.SaveChanges();
		}
		public void CriarEvento(Model.Evento evento)
		{
			evento.Bebida = new Model.Bebida();
			evento.BoloDoceBemCasado = new Model.BoloDoceBemCasado();
			evento.Decoracao = new Model.Decoracao();
			evento.DecoracaoCerimonial = new Model.DecoracaoCerimonial();
			evento.FotoVideo = new Model.FotoVideo();
			evento.Gastronomia = new Model.Gastronomia();
			evento.Montagem = new Model.Montagem();
			evento.OutrosItens = new Model.OutrosItens();
			evento.SomIluminacao = new Model.SomIluminacao();
			context.Evento.Add(evento);
			context.SaveChanges();
			CopiarRoteiroPadrao(evento);
			CopiarCerimonialPadrao(evento);
			CopiarCardapioPadrao(evento);
		}
		public void AcionarEventosTerceiros()
		{
			List<Model.Evento> eventos = new Data.Evento().GetEventosServicoTerceiro();
		}

		public static void GerarOS(int id)
		{
		//TODO: implementar Gerar OS	
		}
	}
}
