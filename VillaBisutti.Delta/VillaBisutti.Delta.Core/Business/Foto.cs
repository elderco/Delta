using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Business
{
	public class Foto
	{
		public void SalvarFoto(Model.Foto foto, int eventoId)
		{
			Data.Context context = new Data.Context();
			string[] attributes;
			switch (foto.Qual)
			{
				case "EV":	//Evento
					Model.Evento evento = context.Evento.Find(eventoId);
					evento.Layout = foto;
					attributes =  new string[]{ "Layout" };
						foreach(string name in context.Entry(evento).CurrentValues.PropertyNames.Except(attributes))
							context.Entry(evento).Property(name).IsModified = false;
						context.Entry(evento).Property("Layout").IsModified = true;
					break;
				case "DR":	//Decoração da recepção
					Model.Decoracao decoracao = context.Decoracao.Find(eventoId);
					break;
				case "DC":	//Decoração do cerimonial
					break;
				case "MS":	//Montagem do salão
					break;
				case "GS":	//Gastronomia
					break;
				case "BB":	//Bebidas
					break;
				case "BD":	//Bolo, doces e bem-casado
					break;
				case "FV":	//Foto e vídeo
					break;
				case "SI":	//Som e iluminação
					break;
				case "OI":	//Outros itens
					break;
			}
			context.SaveChanges();
			context.Dispose();
		}
	}
}
