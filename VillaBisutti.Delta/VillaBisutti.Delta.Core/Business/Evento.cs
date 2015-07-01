using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Business
{
	public class Evento
	{
		public void CopiarRoteiroPadrao(int eventoId)
		{
			Model.Evento evento = new Data.Evento().GetElement(eventoId);
			Model.RoteiroPadrao roteiro = new Data.RoteiroPadrao().GetCollection(0).FirstOrDefault(rp => rp.TipoEvento == evento.TipoEvento);
			List<Model.ItemRoteiro> itens = new List<Model.ItemRoteiro>();
			foreach (Model.ItemRoteiro item in roteiro.Acontecimentos)
				itens.Add(new Model.ItemRoteiro
				{
					Titulo = item.Titulo,
					HorarioInicio = evento.HorarioInicio + item.HorarioInicio,
					EventoId = evento.Id,
					Observacao = item.Observacao
				});
			new Data.ItemRoteiro().AddRange(itens);
		}
		public void CopiarCardapioPadrao(int eventoId)
		{
			Model.Evento evento = new Data.Evento().GetElement(eventoId);
			Model.CardapioPadrao cardapio = new Data.CardapioPadrao().GetCollection(0).FirstOrDefault(cp => cp.CardapioId == evento.CardapioId && cp.TipoServico == evento.TipoServico);
			foreach(Model.Prato p in cardapio.PratosSelecionados)
				evento.Cardapio.Pratos.Add(p);
			new Data.Evento().Update(evento);
		}
		
        public void AcionarEventosTerceiros()
        {
            List<Model.Evento> eventos = new Data.Evento().GetEventosServicoTerceiro();
        }
	}
}
