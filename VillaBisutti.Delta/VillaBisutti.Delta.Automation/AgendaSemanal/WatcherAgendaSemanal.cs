using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using model = VillaBisutti.Delta.Core.Model;
using System.Threading;
using VillaBisutti.Delta.Automation.Helpers;
using bus = VillaBisutti.Delta.Core.Business;

namespace VillaBisutti.Delta.Automation.AgendaSemanal
{
	public class WatcherAgendaSemanal : Watcher
	{
		public override void Run(object state)
        {
            //O serviço nunca para de executar
            TimerExecution.Change(Timeout.Infinite, Timeout.Infinite);

            bus.AgendaSemanal.EnviarEmailAgendaSemanal();
            //Terminou de rodar, prepara a próxima execução
            ExtensionMethods.ModifyDate("DataEmailAgendaSemanal", "FrequenciaAgendaSemanal");
            Date = ExtensionMethods.GetDateXML("DataEmailAgendaSemanal");
            Time = ExtensionMethods.ReturnTimeToRun(Date);
            TimerExecution.Change(Time, Time);
        }
	}
}
	