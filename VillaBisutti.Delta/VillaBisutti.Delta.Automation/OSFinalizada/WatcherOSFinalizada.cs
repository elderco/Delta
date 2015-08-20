using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;
using data = VillaBisutti.Delta.Core.Data;
using bus = VillaBisutti.Delta.Core.Business;
using System.Threading;
using VillaBisutti.Delta.Automation.Helpers;

namespace VillaBisutti.Delta.Automation.OSFinalizada
{
	public class WatcherOSFinalizada: Watcher
	{
        public override void Run(object state)
        {
            TimerExecution.Change(Timeout.Infinite, Timeout.Infinite);
            OSFinalizada();
            //Terminou de rodar, prepara a próxima execução
            ExtensionMethods.ModifyDate("DataFinalizacaoOS","FrequenciaOSFinalizada");
            Date = ExtensionMethods.GetDateXML("DataFinalizacaoOS");
            Time = ExtensionMethods.ReturnTimeToRun(Date);
            TimerExecution.Change(Time, Time);
        }
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
