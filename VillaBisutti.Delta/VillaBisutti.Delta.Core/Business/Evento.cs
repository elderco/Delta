using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Business
{
	public class Evento
	{
		private Data.Context _context;
		public Data.Context context
		{
			get
			{
				if (_context == null)
					_context = new Data.Context();
				return _context;
			}
		}
		public void CopiarRoteiroPadrao(Model.Evento evento, Data.Context CONTEXT)
		{
			_context = CONTEXT;
			CopiarRoteiroPadrao(evento);
		}
		public void CopiarRoteiroPadrao(Model.Evento evento)
		{
			if (evento.Roteiro == null)
				evento.Roteiro = new List<Model.ItemRoteiro>();
			foreach (Model.ItemRoteiro item in context.ItemRoteiro.Where(rp => rp.TipoEvento == evento.TipoEvento && (rp.EventoId == 0 || rp.EventoId == null)))
				evento.Roteiro.Add(new Model.ItemRoteiro
				{
					Titulo = item.Titulo,
					HorarioInicio = evento.HorarioInicio + item.HorarioInicio,
					Observacao = item.Observacao
				});
			context.SaveChanges();
		}
		public void CopiarCerimonialPadrao(Model.Evento evento, Data.Context CONTEXT)
		{
			_context = CONTEXT;
			CopiarCerimonialPadrao(evento);
		}
		public void CopiarCerimonialPadrao(Model.Evento evento)
		{
			if (evento.Cerimonial == null)
				evento.Cerimonial = new List<Model.ItemCerimonial>();
			foreach (Model.ItemCerimonial item in context.ItemCerimonial.Where(rp => rp.TipoEvento == evento.TipoEvento && (rp.EventoId == 0 || rp.EventoId == null)))
				evento.Cerimonial.Add(new Model.ItemCerimonial
				{
					Titulo = item.Titulo,
					HorarioInicio = evento.HorarioInicio + item.HorarioInicio,
					Observacao = item.Observacao
				});
			context.SaveChanges();
		}
		public void CopiarCardapioPadrao(Model.Evento evento, Data.Context CONTEXT)
		{
			_context = CONTEXT;
			CopiarCardapioPadrao(evento);
		}
		public void CopiarCardapioPadrao(Model.Evento evento)
		{
			if (evento.CardapioId == 0 || evento.TipoServicoId == 0)
				return;
			if (evento.Gastronomia.Pratos == null)
				evento.Gastronomia.Pratos = new List<Model.PratoSelecionado>();
			if (evento.Gastronomia.TiposPratos == null)
				evento.Gastronomia.TiposPratos = new List<Model.TipoPratoPadrao>();
			foreach (Model.PratoSelecionado prato in context.PratoSelecionado.Where(p => p.EventoId == null && p.CardapioId == evento.CardapioId && p.TipoServicoId == evento.TipoServicoId))
				evento.Gastronomia.Pratos.Add(new Model.PratoSelecionado
				{
					PratoId = prato.PratoId,
					Degustar = prato.Degustar
				});
			foreach (Model.TipoPratoPadrao tipo in context.TipoPratoPadrao.Where(p => p.EventoId == null && p.CardapioId == evento.CardapioId && p.TipoServicoId == evento.TipoServicoId))
				evento.Gastronomia.TiposPratos.Add(new Model.TipoPratoPadrao
				{
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
			CopiarRoteiroPadrao(evento);
			CopiarCerimonialPadrao(evento);
			CopiarCardapioPadrao(evento);
			context.Evento.Add(evento);
			context.SaveChanges();
		}
		public void AcionarEventosTerceiros()
		{
			List<Model.Evento> eventos = new Data.Evento().GetEventosServicoTerceiro();
		}
	}
}
