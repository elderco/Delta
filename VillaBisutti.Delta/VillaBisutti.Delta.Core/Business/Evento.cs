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
			//Encontrar o roteiro padrão para o tipo de evento igual ao deste evento
			Model.RoteiroPadrao roteiro = new Data.RoteiroPadrao().GetCollection(0).FirstOrDefault(rp => rp.TipoEvento == evento.TipoEvento);
			//passar por cada ItemRoteiro existente no roteiro padrão


				//Criar uma nova instância de ItemRoteiro
				//Atribuit o mesmo nome 
				//Horário do bicho ficará igual à horário do anterior + horário de início do evento
				//EventoId do bicho é o Id do evento
			//adicionar ao context.ItemRoteiro todos estes novos eventos criados
			//Salvar context
		}
	}
}
