using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;
using data = VillaBisutti.Delta.Core.Data;
using bus = VillaBisutti.Delta.Core.Business;

namespace VillaBisutti.Delta.Automation.OSFinalizada
{
	public class WatcherOSFinalizada
	{
		//todos eventos q estao como
			//apriovado = true
			//finalizada = false
			//chama este método e seta finalizado = true 
		public void OSFinalizada()
		{
			List<model.Evento> eventos = Util.context.Evento
				.Include(e => e.Bebida)
				.Include(e => e.BoloDoceBemCasado)
				.Include(e => e.Cardapio)
				.Include(e => e.DecoracaoCerimonial)
				.Include(e => e.FotoVideo)
				.Include(e => e.Gastronomia)
				.Include(e => e.Local)
				.Include(e => e.Montagem)
				.Include(e => e.OutrosItens)
				.Include(e => e.PosVendedora)
				.Include(e => e.Produtora)
				.Include(e => e.SomIluminacao)
			.Where(e => e.OSAprovada == true && e.OSFinalizada == false).ToList();
			foreach (model.Evento item in eventos)
			{
				model.Evento evento = Util.context.Evento.Find(item.Id);
				bus.Evento.GerarOS(item.Id);
				item.OSFinalizada = true;
				Util.context.Entry(evento).OriginalValues.SetValues(item);
			}
			Util.context.SaveChanges();
			Util.ResetContext();
		}
	}
}
