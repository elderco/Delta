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
		//TODO: Implementar método abaixo (Gabriel)
		public void CopiarCardapioPadrao(int eventoId)
		{
			/*
			 * Tal qual o método acima
			 * só que pega o TipoServico e o Cardapio no evento
			 * e pega o CardapioPadrao correspondente
			 * adiciona todos os pratos do CardapioPadrao no Evento
			 */
		}
	}
}
