using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Business
{
	public class Gastronomia
	{
		public void Save(Model.Gastronomia entity)
		{
			Model.Gastronomia original = Util.context.Gastronomia.FirstOrDefault(s => s.EventoId == entity.EventoId);
			Model.Evento evento = Util.context.Evento.FirstOrDefault(e => e.Id == entity.Id);
			Model.Evento modified = Util.context.Evento.FirstOrDefault(e => e.Id == entity.Id);
			bool alterado = (evento.CardapioId != entity.Evento.CardapioId || evento.TipoServicoId != entity.Evento.TipoServicoId);
			modified.CardapioId = entity.Evento.CardapioId;
			modified.TipoServicoId = entity.Evento.TipoServicoId;
			Util.context.Entry(original).CurrentValues.SetValues(entity);
			Util.context.Entry(original).State = System.Data.Entity.EntityState.Modified;
			Util.context.Entry(evento).CurrentValues.SetValues(modified);
			Util.context.Entry(evento).State = System.Data.Entity.EntityState.Modified;
			if(alterado)
			{
				foreach (Model.PratoSelecionado prato in Util.context.PratoSelecionado.Where(p => p.EventoId == entity.Id))
					Util.context.Entry(prato).State = System.Data.Entity.EntityState.Deleted;
				foreach (Model.TipoPratoPadrao tipoPrato in Util.context.TipoPratoPadrao.Where(tp => tp.EventoId == entity.Id))
					Util.context.Entry(tipoPrato).State = System.Data.Entity.EntityState.Deleted;
			}
			Util.context.SaveChanges();
			Util.ResetContext();
		}
		public void GerarCardapioDegustacao(Model.Gastronomia entity)
		{


		}
	}
}
