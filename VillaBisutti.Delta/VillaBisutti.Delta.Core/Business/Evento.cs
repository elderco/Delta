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
			//Encontrar o evento que tem este Id passado por parâmetro.
			Model.Evento evento = new Data.Evento().GetElement(eventoId);
			evento.Roteiro = new Model.Roteiro();
			//Encontrar o roteiro padrão para o tipo de evento igual ao deste evento
			Model.RoteiroPadrao roteiro = new Data.RoteiroPadrao().GetCollection(0).FirstOrDefault(rp => rp.TipoEvento == evento.TipoEvento);
			//passar por cada ItemRoteiro existente no roteiro padrão
			//Model.ItemRoteiro itemroteiro = new Model.ItemRoteiro();
			foreach(Model.ItemRoteiro item in roteiro.Acontecimentos)
			{
				//Criar uma nova instância de ItemRoteiro
				Model.ItemRoteiro itemroteiro = new Model.ItemRoteiro();
				//Atribuit o mesmo nome 
				itemroteiro.Titulo = item.Titulo;
				//Horário do bicho ficará igual à horário do anterior + horário de início do evento
				itemroteiro.HorarioInicio = evento.HorarioInicio + item.HorarioInicio;
				//EventoId do bicho é o Id do evento
				itemroteiro.RoteiroId = evento.Roteiro.Id;
				//context.ItemRoteiro.Add(itemroteiro);
			}
			//adicionar ao context.ItemRoteiro todos estes novos eventos criados
			Data.Context context = new Data.Context();
			//Salvar context
			context.SaveChanges();
		}
	}
}
